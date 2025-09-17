using System.Data;

namespace WayPoint.Model
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DbOutputAttribute : Attribute
    {
        /// <summary> If provided, uses this name instead of the property name for the parameter. </summary>
        public string? ParameterName { get; init; }

        /// <summary> Optional explicit DbType for the parameter. If null, we infer from CLR type. </summary>
        public DbType? DbType { get; init; }
    }
}
