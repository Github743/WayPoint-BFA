using System.Reflection;

namespace WayPoint_Infrastructure.Helpers
{
    public static class DataMappingHelper
    {
        public static T MapKeyValuePairsTo<T>(
            IEnumerable<(string ColumnName, object? Value)> rows,
            Action<T>? customize = null)
            where T : class, new()
        {
            var result = new T();

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .Where(p => p.CanWrite)
                                 .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);

            foreach (var (col, raw) in rows)
            {
                if (string.IsNullOrWhiteSpace(col)) continue;
                if (!props.TryGetValue(col, out var prop)) continue;

                object? value = raw is DBNull ? null : raw;
                if (value == null)
                {
                    if (!prop.PropertyType.IsValueType || Nullable.GetUnderlyingType(prop.PropertyType) != null)
                        prop.SetValue(result, null);
                    continue;
                }

                var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                try
                {
                    object? converted;

                    if (targetType == typeof(string))
                        converted = Convert.ToString(value);
                    else if (targetType == typeof(bool))
                    {
                        if (value is bool b) converted = b;
                        else
                        {
                            var s = Convert.ToString(value)?.Trim();
                            if (int.TryParse(s, out var iv)) converted = iv != 0;
                            else if (bool.TryParse(s, out var bv)) converted = bv;
                            else converted = Convert.ToBoolean(value);
                        }
                    }
                    else if (targetType == typeof(DateTime))
                    {
                        if (value is DateTime dt) converted = dt;
                        else if (DateTime.TryParse(Convert.ToString(value), out var parsed)) converted = parsed;
                        else converted = Convert.ChangeType(value, targetType);
                    }
                    else if (targetType.IsEnum)
                    {
                        if (value is int ei) converted = Enum.ToObject(targetType, ei);
                        else converted = Enum.Parse(targetType, Convert.ToString(value)!, true);
                    }
                    else
                        converted = Convert.ChangeType(value, targetType);

                    prop.SetValue(result, converted);
                }
                catch
                {
                    // swallow or log conversion errors
                }
            }

            customize?.Invoke(result);
            return result;
        }
    }

}
