using System;

namespace BFAWebApp.Infrastructure.Data;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class DbProcPrefixAttribute(string prefix) : Attribute
{
    public string Prefix { get; } = prefix;
}