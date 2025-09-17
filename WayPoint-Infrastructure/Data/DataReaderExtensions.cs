using Microsoft.Data.SqlClient;

namespace WayPoint_Infrastructure.Data
{
    public static class DataReaderExtensions
    {
        public static bool HasColumn(this SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        public static int GetIntSafe(this SqlDataReader reader, string columnName, int fallback = 0)
        {
            if (!reader.HasColumn(columnName)) return fallback;
            var ord = reader.GetOrdinal(columnName);
            return reader.IsDBNull(ord) ? fallback : reader.GetInt32(ord);
        }

        public static string GetStringSafe(this SqlDataReader reader, string columnName, string? fallback = "")
        {
            if (!reader.HasColumn(columnName)) return fallback ?? string.Empty;
            var ord = reader.GetOrdinal(columnName);
            return reader.IsDBNull(ord) ? (fallback ?? string.Empty) : reader.GetString(ord);
        }

        public static bool GetBoolSafe(this SqlDataReader reader, string columnName, bool fallback = false)
        {
            if (!reader.HasColumn(columnName)) return fallback;
            var ord = reader.GetOrdinal(columnName);
            return reader.IsDBNull(ord) ? fallback : reader.GetBoolean(ord);
        }
    }

}
