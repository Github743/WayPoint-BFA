namespace WayPoint_Infrastructure.Data
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DbProcPrefixAttribute(string prefix) : Attribute
    {
        public string Prefix { get; } = prefix;
    }
}
