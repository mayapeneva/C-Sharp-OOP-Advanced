using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var buyers = new List<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var name = input[0];
                var age = int.Parse(input[1]);
                if (input.Length == 4)
                {
                    buyers.Add(new Citizen(name, age, input[2], input[3]));
                }
                else if (input.Length == 3)
                {
                    buyers.Add(new Rebel(name, age, input[2]));
                }
            }

            var command = Console.ReadLine();
            while (command != "End")
            {
                if (buyers.Any(b => b.Name == command))
                {
                    foreach (var buyer in buyers.Where(b => b.Name == command))
                    {
                        buyer.BuyFood();
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(buyers.Select(b => b.Food).Sum());
        }
    }
}