using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using WayPoint.Model;

namespace WayPoint_Infrastructure.Data
{
    public class SqlEngine : ISqlEngine, IDisposable
    {
        private readonly string _connString;
        public SqlEngine(IConfiguration config) =>
            _connString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Missing connection string 'DefaultConnection'.");

        public void Dispose() => GC.SuppressFinalize(this);

        // caches
        private readonly ConcurrentDictionary<Type, PropertyInfo[]> _propsCache = new();
        private readonly ConcurrentDictionary<string, ProcParamMeta[]> _procParamCache = new(StringComparer.OrdinalIgnoreCase);

        private record ProcParamMeta(string ParameterName, ParameterDirection Direction, int Size, SqlDbType SqlDbType);

        #region Retrieve

        public async Task<T> RetrieveObjectAsync<T>(object? parameters, CancellationToken ct = default) where T : class, new()
        {
            var model = new T();
            var procName = ResolveProcName(model, ProcedureType.Get);

            await using var conn = new SqlConnection(_connString);
            await conn.OpenAsync(ct);

            var result = await conn.QueryFirstOrDefaultAsync<T>(new CommandDefinition(
                commandText: procName,
                parameters: parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: ct));

            return result ?? new T();
        }

        public async Task<IReadOnlyList<T>> RetrieveObjectsAsync<T>(object? parameters, CancellationToken ct = default) where T : class, new()
        {
            var model = new T();
            var procName = ResolveProcName(model, ProcedureType.Get);

            await using var conn = new SqlConnection(_connString);
            await conn.OpenAsync(ct);

            var rows = await conn.QueryAsync<T>(new CommandDefinition(procName, parameters, commandType: CommandType.StoredProcedure, cancellationToken: ct));
            return rows.AsList();
        }

        public async IAsyncEnumerable<T> StreamObjectsAsync<T>(object? parameters, [EnumeratorCancellation] CancellationToken ct = default)
            where T : class, new()
        {
            var model = new T();
            var procName = ResolveProcName(model, ProcedureType.Get);

            await using var conn = new SqlConnection(_connString);
            await conn.OpenAsync(ct);

            await using var cmd = new SqlCommand(procName, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };

            // support: DynamicParameters, IEnumerable<SqlParameter>, anonymous/POCO
            if (parameters != null)
            {
                if (parameters is DynamicParameters dp)
                {
                    foreach (var name in dp.ParameterNames)
                    {
                        object? value = null;
                        try { value = dp.Get<object>(name); } catch { value = DBNull.Value; }
                        cmd.Parameters.Add(new SqlParameter("@" + name, value ?? DBNull.Value));
                    }
                }
                else if (parameters is IEnumerable<SqlParameter> sqlParams)
                {
                    foreach (var p in sqlParams)
                    {
                        var np = new SqlParameter(p.ParameterName.StartsWith("@") ? p.ParameterName : "@" + p.ParameterName, p.Value ?? DBNull.Value)
                        {
                            Direction = p.Direction,
                            SqlDbType = p.SqlDbType,
                            Size = p.Size,
                            IsNullable = p.IsNullable
                        };
                        cmd.Parameters.Add(np);
                    }
                }
                else
                {
                    var dd = new DynamicParameters(parameters);
                    foreach (var name in dd.ParameterNames)
                    {
                        object? value = null;
                        try { value = dd.Get<object>(name); } catch { value = DBNull.Value; }
                        cmd.Parameters.Add(new SqlParameter("@" + name, value ?? DBNull.Value));
                    }
                }
            }

            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.Default, ct);
            var parser = reader.GetRowParser<T>();
            while (await reader.ReadAsync(ct))
            {
                ct.ThrowIfCancellationRequested();
                yield return parser(reader);
            }
        }

        public async Task<(IEnumerable<T> Rows, DynamicParameters? Params)> RetrieveObjectsWithOutputsAsync<T>(
    object? parameters,
    CancellationToken ct = default) where T : class, new()
        {
            var model = new T();
            var procName = ResolveProcName(model, ProcedureType.Get);

            DynamicParameters? dp = null;
            if (parameters is DynamicParameters existingDp)
                dp = existingDp;
            else if (parameters != null)
                dp = new DynamicParameters(parameters);

            await using var conn = new SqlConnection(_connString);
            await conn.OpenAsync(ct);

            // buffered by default → OUTPUT params populated after this call
            var rows = await conn.QueryAsync<T>(new CommandDefinition(
                procName,
                dp ?? parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: ct));

            return (rows.AsList(), dp);
        }
        #endregion

        #region SaveEntityAsync (interface signature preserved)

        public async Task<T> SaveEntityAsync<T>(T entity, DynamicParameters? parameters = null,
            IDbTransaction? tran = null, CancellationToken ct = default) where T : class, new()
        {
            ArgumentNullException.ThrowIfNull(entity);

            var procType = GetProcTypeFromEntity(entity);
            var procName = ResolveProcName(entity, procType);

            var usedParams = BuildDynamicParametersFromEntity(procName, entity, parameters);

            SqlConnection? conn = (tran as SqlTransaction)?.Connection;
            var createdConn = false;
            if (tran != null && conn == null)
                throw new InvalidOperationException("Provided transaction has no associated connection.");

            if (conn == null)
            {
                conn = new SqlConnection(_connString);
                await conn.OpenAsync(ct);
                createdConn = true;
            }

            try
            {
                var mapped = await conn.QueryFirstOrDefaultAsync<T>(new CommandDefinition(
                    commandText: procName,
                    parameters: usedParams,
                    transaction: tran,
                    commandType: CommandType.StoredProcedure,
                    cancellationToken: ct));

                if (mapped != null)
                    entity = mapped;

                return entity;
            }
            finally
            {
                if (createdConn && conn != null) await conn.DisposeAsync();
            }
        }

        #endregion

        #region Transactions

        public async Task<T> WithDbTransactionAsync<T>(Func<SqlConnection, SqlTransaction, Task<T>> operation,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(operation);

            await using var conn = new SqlConnection(_connString);
            await conn.OpenAsync(ct);

            using var tran = conn.BeginTransaction(isolationLevel);

            try
            {
                var result = await operation(conn, tran);
                tran.Commit();
                return result;
            }
            catch
            {
                try { tran.Rollback(); } catch { }
                throw;
            }
        }

        public async Task WithDbTransactionAsync(Func<SqlConnection, SqlTransaction, Task> operation,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(operation);

            await using var conn = new SqlConnection(_connString);
            await conn.OpenAsync(ct);

            using var tran = conn.BeginTransaction(isolationLevel);

            try
            {
                await operation(conn, tran);
                tran.Commit();
            }
            catch
            {
                try { tran.Rollback(); } catch { }
                throw;
            }
        }

        #endregion

        #region Helpers: ResolveProcName, proc metadata, params, outputs, type maps

        private DynamicParameters BuildDynamicParametersFromEntity<T>(string procName, T? entity, DynamicParameters? callerParams = null)
            where T : class
        {
            Dictionary<string, PropertyInfo>? propsByName = null;
            if (entity != null)
            {
                var attrType = typeof(DbIgnoreAttribute);
                propsByName = entity.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && !Attribute.IsDefined(p, attrType))
                    .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
            }

            if (callerParams == null)
            {
                var dp = new DynamicParameters();

                if (propsByName != null)
                {
                    foreach (var kv in propsByName)
                    {
                        var name = kv.Key;
                        var pi = kv.Value;
                        object? value;
                        try { value = pi.GetValue(entity); }
                        catch { value = null; }

                        dp.Add(name, value);
                    }
                }

                return dp;
            }

            var existingNames = new HashSet<string>(callerParams.ParameterNames, StringComparer.OrdinalIgnoreCase);

            if (propsByName != null)
            {
                foreach (var kv in propsByName)
                {
                    var propName = kv.Key;
                    if (existingNames.Contains(propName))
                    {
                        continue;
                    }

                    var pi = kv.Value;
                    object? value;
                    try { value = pi.GetValue(entity); }
                    catch { value = null; }
                    callerParams.Add(propName, value);
                }
            }
            return callerParams;
        }
        private static string ResolveProcName<T>(T entity, ProcedureType type) where T : class, new()
        {
            var getProc = entity.GetType().GetMethod("GetProcedureName", new[] { typeof(ProcedureType) });
            if (getProc != null)
                return (string)getProc.Invoke(entity, new object[] { type })!;

            var baseName = entity.GetType().Name;
            var suffix = type switch
            {
                ProcedureType.Create => "Create",
                ProcedureType.Update => "Update",
                ProcedureType.Delete => "Delete",
                ProcedureType.Get => "Get",
                _ => "Proc"
            };
            return $"dbo.{baseName}_{suffix}";
        }

        private static ProcedureType GetProcTypeFromEntity<T>(T entity) where T : class
        {
            var msProp = entity.GetType().GetProperty("ModelState", BindingFlags.Public | BindingFlags.Instance);
            if (msProp != null)
            {
                var val = msProp.GetValue(entity);
                if (val is Enum)
                {
                    var name = val.ToString();
                    return name switch
                    {
                        "New" => ProcedureType.Create,
                        "Modified" => ProcedureType.Update,
                        "Deleted" => ProcedureType.Delete,
                        _ => ProcedureType.Create
                    };
                }
            }
            return ProcedureType.Create;
        }

        private PropertyInfo[] GetProps(Type t)
        {
            return _propsCache.GetOrAdd(t, tt =>
                tt.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                  .Where(p => p.CanRead || p.CanWrite)
                  .ToArray());
        }

        private ProcParamMeta[] GetOrDeriveProcParams(string procName)
        {
            if (_procParamCache.TryGetValue(procName, out var cached)) return cached;

            using var conn = new SqlConnection(_connString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;

            SqlCommandBuilder.DeriveParameters(cmd);

            var list = new List<ProcParamMeta>(cmd.Parameters.Count);
            foreach (SqlParameter p in cmd.Parameters)
            {
                if (string.Equals(p.ParameterName, "@RETURN_VALUE", StringComparison.OrdinalIgnoreCase))
                    continue;

                list.Add(new ProcParamMeta(p.ParameterName, p.Direction, p.Size, p.SqlDbType));
            }

            var arr = list.ToArray();
            _procParamCache.TryAdd(procName, arr);
            return arr;

            // local helper to avoid direct TryGetValue call duplication
            bool _proc_param_cache_tryget(string name, out ProcParamMeta[]? value)
            {
                return _procParamCache.TryGetValue(name, out value);
            }
        }

        private DynamicParameters BuildDynamicParametersForStoredProc<T>(string procName, T? entity) where T : class
        {
            var dp = new DynamicParameters();
            var metas = GetOrDeriveProcParams(procName);

            Dictionary<string, PropertyInfo>? propsByName = null;
            if (entity != null)
            {
                propsByName = GetProps(entity.GetType())
                    .Where(p => p.CanRead)
                    .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
            }

            foreach (var meta in metas)
            {
                var paramNoAt = meta.ParameterName.StartsWith("@") ? meta.ParameterName.Substring(1) : meta.ParameterName;

                if (meta.Direction == ParameterDirection.Output || meta.Direction == ParameterDirection.InputOutput)
                {
                    var dbType = MapSqlDbTypeToDbType(meta.SqlDbType);
                    dp.Add(paramNoAt, dbType: dbType, direction: ParameterDirection.Output, size: meta.Size > 0 ? meta.Size : (int?)null);
                }

                if (meta.Direction == ParameterDirection.Input || meta.Direction == ParameterDirection.InputOutput)
                {
                    object? value = null;
                    var found = false;
                    if (propsByName != null && propsByName.TryGetValue(paramNoAt, out var pi))
                    {
                        value = pi.GetValue(entity);
                        found = true;
                    }
                    dp.Add(paramNoAt, found ? (value ?? DBNull.Value) : DBNull.Value);
                }
            }

            return dp;
        }

        private static DbType MapSqlDbTypeToDbType(SqlDbType sqlDbType)
        {
            return sqlDbType switch
            {
                SqlDbType.Int => DbType.Int32,
                SqlDbType.BigInt => DbType.Int64,
                SqlDbType.SmallInt => DbType.Int16,
                SqlDbType.TinyInt => DbType.Byte,
                SqlDbType.Bit => DbType.Boolean,
                SqlDbType.VarChar => DbType.String,
                SqlDbType.NVarChar => DbType.String,
                SqlDbType.Char => DbType.String,
                SqlDbType.NChar => DbType.String,
                SqlDbType.DateTime => DbType.DateTime,
                SqlDbType.DateTime2 => DbType.DateTime2,
                SqlDbType.Date => DbType.Date,
                SqlDbType.Decimal => DbType.Decimal,
                SqlDbType.Money => DbType.Decimal,
                SqlDbType.Float => DbType.Double,
                SqlDbType.Real => DbType.Single,
                SqlDbType.UniqueIdentifier => DbType.Guid,
                SqlDbType.VarBinary => DbType.Binary,
                SqlDbType.Binary => DbType.Binary,
                _ => DbType.Object
            };
        }

        private static void PopulateOutputsToEntity<T>(T entity, DynamicParameters? parameters) where T : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (parameters == null) return;

            var writeableProps = entity.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite)
                .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);

            foreach (var paramName in parameters.ParameterNames)
            {
                if (string.IsNullOrWhiteSpace(paramName)) continue;

                object? rawValue;
                try
                {
                    rawValue = parameters.Get<object>(paramName);
                }
                catch (KeyNotFoundException) { continue; }

                if (rawValue == null || rawValue == DBNull.Value) continue;

                if (writeableProps.TryGetValue(paramName, out var propInfo))
                {
                    var targetType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;
                    try
                    {
                        if (targetType.IsAssignableFrom(rawValue.GetType()))
                        {
                            propInfo.SetValue(entity, rawValue);
                        }
                        else
                        {
                            var converted = Convert.ChangeType(rawValue, targetType);
                            propInfo.SetValue(entity, converted);
                        }
                    }
                    catch
                    {
                        // swallow conversion errors - you can log here
                    }
                }
            }
        }

        #endregion
    }
}
