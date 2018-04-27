using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        var result = new StringBuilder();

        var classType = Type.GetType(className);
        var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var methodInfo in methods.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
        }

        foreach (var methodInfo in methods.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
        }

        return result.ToString().Trim();
    }
}