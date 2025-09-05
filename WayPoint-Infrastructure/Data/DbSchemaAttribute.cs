namespace WayPoint_Infrastructure.Data
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DbSchemaAttribute(string name) : Attribute
    {
        public string Name { get; } = name;
    }
}
