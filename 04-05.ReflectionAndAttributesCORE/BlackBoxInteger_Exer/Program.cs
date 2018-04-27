using P02_BlackBoxInteger;
using System;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        var classType = typeof(BlackBoxInteger);
        var classInstance = (BlackBoxInteger)Activator.CreateInstance(classType, true);

        var field = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First();

        var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split('_').ToArray();
            var command = tokens[0];
            var number = int.Parse(tokens[1]);
            methods.First(m => m.Name.Equals(command)).Invoke(classInstance, new object[] { number });

            Console.WriteLine(field.GetValue(classInstance));
        }
    }
}