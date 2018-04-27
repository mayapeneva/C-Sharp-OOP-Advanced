using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        var result = new StringBuilder();
        result.AppendLine($"Class under investigation: {classToInvestigate}");

        var classType = Type.GetType(classToInvestigate);
        var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        var classInstance = Activator.CreateInstance(classType);
        foreach (var fieldInfo in fields)
        {
            if (fieldsToInvestigate.Contains(fieldInfo.Name))
            {
                result.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");
            }
        }

        return result.ToString().Trim();
    }
}