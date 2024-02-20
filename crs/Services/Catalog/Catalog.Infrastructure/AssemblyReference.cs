using System.Reflection;

namespace Catalog.Infrastructure;

public static class AssemblyReference
{
    public static Assembly Assembly = typeof(AssemblyReference).Assembly;
}
