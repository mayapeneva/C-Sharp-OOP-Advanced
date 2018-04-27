using System;
using System.Linq;

public class Program
{
    private static ListIterator iterator;

    public static void Main()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split().ToArray();
            var command = tokens[0];
            try
            {
                switch (command)
                {
                    case "Create":
                        iterator = new ListIterator(tokens.Skip(1).ToList());
                        break;

                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;

                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;

                    case "Print":
                        iterator.Print();
                        break;
                }
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}