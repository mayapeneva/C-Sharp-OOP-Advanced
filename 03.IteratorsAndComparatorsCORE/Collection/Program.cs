using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var listyIterator = new ListyIterator<string>();

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
                        listyIterator = new ListyIterator<string>(tokens.Skip(1).ToArray());
                        break;

                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;

                    case "Print":
                        Console.WriteLine(listyIterator.Print());
                        break;

                    case "PrintAll":
                        Console.WriteLine(listyIterator.PrintAll());
                        break;

                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                }
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}