using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WayPoint_Infrastructure.Data
{
    public interface IEfReadEngine<TContext> where TContext : DbContext
    {
        Task<IReadOnlyList<T>> RetrieveAsync<T>(
        Expression<Func<T, bool>>? predicate = null,
        IEnumerable<string>? includes = null,
        CancellationToken ct = default)
        where T : class;

        Task<IReadOnlyList<TResult>> RetrieveProjectedAsync<T, TResult>(
            Expression<Func<T, bool>>? predicate,
            Expression<Func<T, TResult>> selector,
            IEnumerable<string>? includes = null,
            Func<IQueryable<TResult>, IOrderedQueryable<TResult>>? orderBy = null,
            int? page = null,
            int? pageSize = null,
            CancellationToken ct = default) where T : class;

        Task<IReadOnlyList<TResult>> ExecuteQueryAsync<TResult>(
            Func<TContext, IQueryable<TResult>> queryBuilder, 
            CancellationToken ct = default);

        Task<TEntity> SaveEntity<TEntity>(TEntity entity, CancellationToken ct = default)
            where TEntity : class;

        Task<List<TEntity>> SaveEntities<TEntity>(
           IEnumerable<TEntity> entities,
           bool useTransaction = true,
           Func<TContext, List<TEntity>, CancellationToken, Task>? bulkOperation = null,
           CancellationToken ct = default) where TEntity : class;
    }
}
