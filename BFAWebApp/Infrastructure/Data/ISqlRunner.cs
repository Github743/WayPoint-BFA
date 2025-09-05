using Microsoft.Data.SqlClient;

namespace BFAWebApp.Infrastructure.Data;

public interface ISqlRunner
{
    Task<IReadOnlyList<TModel>> QueryProcAsync<TProc, TModel>(
        SqlVerb verb,
        IEnumerable<SqlParameter>? parameters = null,
        Func<SqlDataReader, TModel>? map = null,
        int commandTimeoutSeconds = 30,
        CancellationToken ct = default)
        where TProc : IStoredProcMarker, new();

    Task<TModel?> QuerySingleProcAsync<TProc, TModel>(
        SqlVerb verb,
        IEnumerable<SqlParameter>? parameters = null,
        Func<SqlDataReader, TModel>? map = null,
        int commandTimeoutSeconds = 30,
        CancellationToken ct = default)
        where TProc : IStoredProcMarker, new();

    Task<int> ExecuteProcAsync<TProc>(
        SqlVerb verb,
        IEnumerable<SqlParameter>? parameters = null,
        int commandTimeoutSeconds = 30,
        CancellationToken ct = default)
        where TProc : IStoredProcMarker, new();
}
