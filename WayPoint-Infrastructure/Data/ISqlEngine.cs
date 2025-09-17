using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WayPoint_Infrastructure.Data
{
    public interface ISqlEngine : IDisposable
    {
        Task<T> RetrieveObjectAsync<T>(object? parameters, CancellationToken ct = default) where T : class, new();
        Task<IReadOnlyList<T>> RetrieveObjectsAsync<T>(object? parameters, CancellationToken ct = default) where T : class, new();
        Task<(IEnumerable<T> Rows, DynamicParameters? Params)> RetrieveObjectsWithOutputsAsync<T>(object? parameters, CancellationToken ct = default) where T : class, new();
        IAsyncEnumerable<T> StreamObjectsAsync<T>(object? parameters, CancellationToken ct = default) where T : class, new();
        Task<T> SaveEntityAsync<T>(T entity, DynamicParameters? parameters = null, IDbTransaction? tran = null, CancellationToken ct = default) where T : class, new();
        // in ISqlEngine (WayPoint_Infrastructure.Data)
        Task<T> WithDbTransactionAsync<T>(Func<SqlConnection, SqlTransaction, Task<T>> operation,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken ct = default);

        Task WithDbTransactionAsync(Func<SqlConnection, SqlTransaction, Task> operation,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken ct = default);

    }
}
