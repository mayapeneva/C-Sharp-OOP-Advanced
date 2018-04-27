using System;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        var repository = new Repository();
        var interpreter = new CommandInerpreter();
        var engine = new Engine(repository, interpreter);
        engine.Run();

        //GetAttributeInfo();
    }

    private static void GetAttributeInfo()
    {
        var classType = Type.GetType("Weapon");
        var attributes = classType.GetCustomAttributes();
        var attribute = (CustomAttribute)attributes.First();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            switch (input)
            {
                case "Author":
                    Console.WriteLine(attribute.Author);
                    break;

                case "Revision":
                    Console.WriteLine(attribute.Revision);
                    break;

                case "Description":
                    Console.WriteLine(attribute.Description);
                    break;

                case "Reviewers":
                    Console.WriteLine(attribute.Reviewers);
                    break;
            }
        }
    }
}