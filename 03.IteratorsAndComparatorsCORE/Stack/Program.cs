using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var stack = new Stack<string>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var command = tokens[0];
            try
            {
                switch (command)
                {
                    case "Push":
                        foreach (var item in tokens.Skip(1).ToArray())
                        {
                            stack.Push(item.Trim(','));
                        }
                        break;

                    case "Pop":
                        stack.Pop();
                        break;
                }
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}