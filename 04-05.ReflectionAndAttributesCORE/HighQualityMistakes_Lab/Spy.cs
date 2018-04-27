using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        var result = new StringBuilder();

        var classType = Type.GetType(className);
        var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        foreach (var fieldInfo in fields)
        {
            result.AppendLine($"{fieldInfo.Name} must be private!");
        }

        var privateProperties = classType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
        foreach (var propertyInfo in privateProperties)
        {
            result.AppendLine($"{propertyInfo.GetMethod.Name} have to be public!");
        }

        var publicProperties = classType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        foreach (var propertyInfo in publicProperties)
        {
            result.AppendLine($"{propertyInfo.SetMethod.Name} have to be private!");
        }

        return result.ToString().Trim();
    }
}