using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        var result = new StringBuilder();
        result.AppendLine($"All Private Methods of Class: {className}");

        var classType = Type.GetType(className);
        var baseClass = classType.BaseType;
        result.AppendLine($"Base Class: {baseClass.Name}");

        var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (var methodInfo in methods)
        {
            result.AppendLine($"{methodInfo.Name}");
        }

        return result.ToString().Trim();
    }
}