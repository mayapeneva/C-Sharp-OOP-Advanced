using System.Linq;
using System.Reflection;
using System.Text;

namespace _01HarestingFields
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var classType = Type.GetType("_01HarestingFields.HarvestingFields");
            var fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            var result = new StringBuilder();
            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                if (input == "all")
                {
                    foreach (FieldInfo fieldInfo in fieldsInfo)
                    {
                        result.AppendLine($"{fieldInfo.Attributes.ToString().ToLower()} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                    }
                }

                input = input == "protected" ? "family" : input;
                foreach (FieldInfo fieldInfo in fieldsInfo.Where(f => f.Attributes.ToString().ToLower().StartsWith(input)))
                {
                    result.AppendLine($"{fieldInfo.Attributes.ToString().ToLower()} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));
        }
    }
}