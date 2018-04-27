using System;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        var classType = Type.GetType("HarvestingFields");

        string input;
        while ((input = Console.ReadLine()) != "HARVEST")
        {
            FieldInfo[] fields =
                classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            FieldInfo[] result;
            switch (input)
            {
                case "private":
                    result = fields.Where(f => f.IsPrivate).ToArray();
                    break;

                case "protected":
                    result = fields.Where(f => f.IsFamily).ToArray();
                    break;

                case "public":
                    result = fields.Where(f => f.IsPublic).ToArray();
                    break;

                default:
                    result = fields;
                    break;
            }

            foreach (var fieldInfo in result)
            {
                var output = $"{fieldInfo.Attributes.ToString().ToLower()} {fieldInfo.FieldType.Name} {fieldInfo.Name}";
                Console.WriteLine(output.Replace("family", "protected"));
            }
        }
    }
}