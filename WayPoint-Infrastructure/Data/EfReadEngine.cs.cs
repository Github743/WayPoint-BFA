using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Reflection;

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
        public async Task<TEntity> SaveEntity<TEntity>(TEntity entity, CancellationToken ct = default)
            where TEntity : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await using var ctx = _factory.CreateDbContext();

            var entityType = ctx.Model.FindEntityType(typeof(TEntity))
                             ?? throw new InvalidOperationException($"Entity type {typeof(TEntity).Name} is not part of the DbContext model.");

            var pk = entityType.FindPrimaryKey() ?? throw new InvalidOperationException($"No primary key defined on {typeof(TEntity).Name}.");
            var pkProps = pk.Properties.Select(p => p.PropertyInfo ?? throw new InvalidOperationException($"PK property {p.Name} has no PropertyInfo")).ToArray();

            var prevAutoDetect = ctx.ChangeTracker.AutoDetectChangesEnabled;
            try
            {
                ctx.ChangeTracker.AutoDetectChangesEnabled = false;

                var isNew = IsPrimaryKeyDefault(entity, pkProps);

                if (isNew)
                    await ctx.Set<TEntity>().AddAsync(entity, ct);
                else
                    ctx.Set<TEntity>().Update(entity);

                await ctx.SaveChangesAsync(ct);

                return entity;
            }
            finally
            {
                ctx.ChangeTracker.AutoDetectChangesEnabled = prevAutoDetect;
            }
        }

        public async Task<List<TEntity>> SaveEntities<TEntity>(
           IEnumerable<TEntity> entities,
           bool useTransaction = true,
           Func<TContext, List<TEntity>, CancellationToken, Task>? bulkOperation = null,
           CancellationToken ct = default) where TEntity : class
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var list = entities.ToList();
            if (!list.Any()) return new List<TEntity>();

            await using var ctx = _factory.CreateDbContext();

            var entityType = ctx.Model.FindEntityType(typeof(TEntity))
                             ?? throw new InvalidOperationException($"Entity type {typeof(TEntity).Name} is not part of the DbContext model.");

            var pk = entityType.FindPrimaryKey() ?? throw new InvalidOperationException($"No primary key defined on {typeof(TEntity).Name}.");
            var pkProps = pk.Properties.Select(p => p.PropertyInfo ?? throw new InvalidOperationException($"PK property {p.Name} has no PropertyInfo")).ToArray();

            var prevAutoDetect = ctx.ChangeTracker.AutoDetectChangesEnabled;
            try
            {
                ctx.ChangeTracker.AutoDetectChangesEnabled = false;

                await using var tx = useTransaction ? await ctx.Database.BeginTransactionAsync(ct) : null;

                if (bulkOperation != null)
                {
                    // delegate to external bulk operation (e.g. EFCore.BulkExtensions)
                    await bulkOperation(ctx, list, ct);
                }
                else
                {
                    // Partition into new vs existing
                    var toAdd = list.Where(e => IsPrimaryKeyDefault(e, pkProps)).ToList();
                    var toUpdate = list.Except(toAdd).ToList();

                    if (toAdd.Count > 0)
                        await ctx.Set<TEntity>().AddRangeAsync(toAdd, ct);

                    if (toUpdate.Count > 0)
                        ctx.Set<TEntity>().UpdateRange(toUpdate);

                    await ctx.SaveChangesAsync(ct);
                }

                if (tx != null)
                    await tx.CommitAsync(ct);

                return list;
            }
            finally
            {
                ctx.ChangeTracker.AutoDetectChangesEnabled = prevAutoDetect;
            }
        }

        private static bool IsPrimaryKeyDefault<TEntity>(TEntity entity, PropertyInfo[] pkProps)
        {
            foreach (var p in pkProps)
            {
                var val = p.GetValue(entity);
                if (!IsDefaultValue(val)) return false;
            }
            return true;
        }

        private static bool IsDefaultValue(object? value)
        {
            if (value == null) return true;

            return value switch
            {
                int i => i == 0,
                long l => l == 0L,
                Guid g => g == Guid.Empty,
                short s => s == 0,
                byte b => b == 0,
                string s => string.IsNullOrEmpty(s),
                _ => false
            };
        }

    }


}
