using System;

namespace Tuple_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().Split();
            Console.WriteLine(new Tuple<string, string>($"{tokens[0]} {tokens[1]}", tokens[2]).ToString());

            tokens = Console.ReadLine().Split();
            Console.WriteLine(new Tuple<string, int>(tokens[0], int.Parse(tokens[1])).ToString());

            tokens = Console.ReadLine().Split();
            Console.WriteLine(new Tuple<int, double>(int.Parse(tokens[0]), double.Parse(tokens[1])).ToString());
        }
    }
}