using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var classType = Type.GetType("Program");
        var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        foreach (var methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                foreach (var attribute in methodInfo.GetCustomAttributes<SoftUniAttribute>())
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}