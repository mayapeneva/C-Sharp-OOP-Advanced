using System;

namespace Threeuple_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().Split();
            Console.WriteLine(new Threeuple<string, string, string>($"{tokens[0]} {tokens[1]}", tokens[2], tokens[3]));

            tokens = Console.ReadLine().Split();
            var ifDrunk = tokens[2] == "drunk";
            Console.WriteLine(new Threeuple<string, int, bool>(tokens[0], int.Parse(tokens[1]), ifDrunk));

            tokens = Console.ReadLine().Split();
            Console.WriteLine(new Threeuple<string, double, string>(tokens[0], double.Parse(tokens[1]), tokens[2]));
        }
    }
}