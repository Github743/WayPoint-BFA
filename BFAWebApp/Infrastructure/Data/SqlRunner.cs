using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace BFAWebApp.Infrastructure.Data
{
    public class SqlRunner : ISqlRunner
    {
        private readonly string _connString;

        public SqlRunner(IConfiguration config)
        {
            _connString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Missing connection string 'DefaultConnection'.");
        }

        private static (string Schema, string BaseName, string Prefix) ResolveProcParts<TProc>() where TProc : IStoredProcMarker
        {
            var t = typeof(TProc);

            var schema = t.GetCustomAttributes(typeof(DbSchemaAttribute), false)
                          .Cast<DbSchemaAttribute>()
                          .FirstOrDefault()?.Name
                       ?? throw new InvalidOperationException($"{t.Name} is missing [DbSchema(\"...\")] attribute.");

            var baseName = t.GetCustomAttributes(typeof(DbProcBaseNameAttribute), false)
                            .Cast<DbProcBaseNameAttribute>()
                            .FirstOrDefault()?.BaseName
                         ?? t.Name;

            var prefix = "usp_";

            return (schema, baseName, prefix);
        }

        private static string ResolveProcName<TProc>(SqlVerb verb) where TProc : IStoredProcMarker
        {
            var (schema, baseName, prefix) = ResolveProcParts<TProc>();
            var verbPart = verb.ToString();
            return $"{schema}.{prefix}{verbPart}{baseName}";
        }

        private static T MapByName<T>(SqlDataReader r)
        {
            var obj = Activator.CreateInstance<T>();
            if (obj == null) throw new InvalidOperationException($"Unable to create instance of type {typeof(T).FullName}.");

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .Where(p => p.CanWrite)
                                 .ToArray();

            for (int i = 0; i < r.FieldCount; i++)
            {
                var colName = r.GetName(i);
                var prop = props.FirstOrDefault(p => p.Name.Equals(colName, StringComparison.OrdinalIgnoreCase));
                if (prop == null) continue;

                var val = r.GetValue(i);
                if (val == DBNull.Value) continue;

                var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                var safeVal = Convert.ChangeType(val, targetType);
                prop.SetValue(obj, safeVal);
            }

            return (T)obj;
        }

        public async Task<IReadOnlyList<TModel>> QueryProcAsync<TProc, TModel>(
            SqlVerb verb,
            IEnumerable<SqlParameter>? parameters = null,
            Func<SqlDataReader, TModel>? map = null,
            int commandTimeoutSeconds = 30,
            CancellationToken ct = default)
            where TProc : IStoredProcMarker, new()
        {
            var proc = ResolveProcName<TProc>(verb);
            var list = new List<TModel>();

            await using var conn = new SqlConnection(_connString);
            await conn.OpenAsync(ct);

            await using var cmd = new SqlCommand(proc, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = commandTimeoutSeconds
            };

            if (parameters != null)
            {
                foreach (var p in parameters) cmd.Parameters.Add(p);
            }

            await using var reader = await cmd.ExecuteReaderAsync(ct);

            Func<SqlDataReader, TModel> mapper = map ?? (r => MapByName<TModel>(r));

            while (await reader.ReadAsync(ct))
            {
                list.Add(mapper(reader));
            }

            return list;
        }

        public async Task<TModel?> QuerySingleProcAsync<TProc, TModel>(
            SqlVerb verb,
            IEnumerable<SqlParameter>? parameters = null,
            Func<SqlDataReader, TModel>? map = null,
            int commandTimeoutSeconds = 30,
            CancellationToken ct = default)
            where TProc : IStoredProcMarker, new()
        {
            var proc = ResolveProcName<TProc>(verb);

            await using var conn = new SqlConnection(_connString);
            await conn.OpenAsync(ct);

            await using var cmd = new SqlCommand(proc, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = commandTimeoutSeconds
            };

            if (parameters != null)
            {
                foreach (var p in parameters) cmd.Parameters.Add(p);
            }

            await using var reader = await cmd.ExecuteReaderAsync(ct);

            Func<SqlDataReader, TModel> mapper = map ?? (r => MapByName<TModel>(r));

            if (await reader.ReadAsync(ct))
            {
                return mapper(reader);
            }

            return default;
        }

        public async Task<int> ExecuteProcAsync<TProc>(
            SqlVerb verb,
            IEnumerable<SqlParameter>? parameters = null,
            int commandTimeoutSeconds = 30,
            CancellationToken ct = default)
            where TProc : IStoredProcMarker, new()
        {
            var proc = ResolveProcName<TProc>(verb);

            await using var conn = new SqlConnection(_connString);
            await conn.OpenAsync(ct);

            await using var cmd = new SqlCommand(proc, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = commandTimeoutSeconds
            };

            if (parameters != null)
            {
                foreach (var p in parameters) cmd.Parameters.Add(p);
            }

            var result = await cmd.ExecuteNonQueryAsync(ct);
            return result;
        }
    }
}