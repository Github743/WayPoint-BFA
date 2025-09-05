namespace BFAWebApp.Infrastructure.Data;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class DbProcBaseNameAttribute(string baseName) : Attribute
{
    public string BaseName { get; } = baseName;
}
