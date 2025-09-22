using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace WayPoint_Infrastructure.Data
{
    public class EfReadEngine<TContext> : IEfReadEngine<TContext> where TContext : DbContext
    {
        private readonly IDbContextFactory<TContext> _factory;

        public EfReadEngine(IDbContextFactory<TContext> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task<IReadOnlyList<TResult>> ExecuteQueryAsync<TResult>(
            Func<TContext, IQueryable<TResult>> queryBuilder, CancellationToken ct = default)
        {
            if (queryBuilder == null) throw new ArgumentNullException(nameof(queryBuilder));
            await using var ctx = _factory.CreateDbContext();

            IQueryable<TResult> query;
            try
            {
                query = queryBuilder(ctx) ?? throw new InvalidOperationException("Query builder returned null.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Query builder threw while building the query. Inspect the lambda for invalid member access.", ex);
            }

            try
            {
                return await query.ToListAsync(ct); // AsNoTracking optional
            }
            catch (SqlNullValueException snv)
            {
                // rethrow with helpful hint
                var message = "SqlNullValueException while materializing query result. " +
                              "This usually means a DB NULL was read into a non-nullable CLR type. " +
                              "Check the projected properties and your entity/DTO nullability.";
                throw new InvalidOperationException(message, snv);
            }
        }

        public async Task<IReadOnlyList<T>> RetrieveAsync<T>(
            Expression<Func<T, bool>>? predicate = null,
            IEnumerable<string>? includes = null,
            CancellationToken ct = default) where T : class
        {
            await using var ctx = _factory.CreateDbContext();

            IQueryable<T> q = ctx.Set<T>().AsNoTracking();

            if (includes != null)
                q = includes.Aggregate(q, (current, inc) => current.Include(inc));

            if (predicate != null)
                q = q.Where(predicate);

            return await q.ToListAsync(ct);
        }

        public async Task<IReadOnlyList<TResult>> RetrieveProjectedAsync<T, TResult>(
            Expression<Func<T, bool>>? predicate,
            Expression<Func<T, TResult>> selector,
            IEnumerable<string>? includes = null,
            Func<IQueryable<TResult>, IOrderedQueryable<TResult>>? orderBy = null,
            int? page = null,
            int? pageSize = null,
            CancellationToken ct = default) where T : class
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            await using var ctx = _factory.CreateDbContext();

            IQueryable<T> q = ctx.Set<T>().AsNoTracking();

            // apply includes (on the source query) so navigation properties referenced inside the selector can be translated
            if (includes != null)
            {
                foreach (var inc in includes)
                {
                    if (!string.IsNullOrWhiteSpace(inc))
                        q = q.Include(inc);
                }
            }

            if (predicate != null)
                q = q.Where(predicate);

            // apply projection
            IQueryable<TResult> projected = q.Select(selector);

            // apply ordering on the projected sequence (if provided)
            if (orderBy != null)
                projected = orderBy(projected);

            // apply paging if requested
            if (page.HasValue && pageSize.HasValue)
            {
                var p = Math.Max(1, page.Value);
                var ps = Math.Max(1, pageSize.Value);
                projected = projected.Skip((p - 1) * ps).Take(ps);
            }

            return await projected.ToListAsync(ct);
        }

    }
}
