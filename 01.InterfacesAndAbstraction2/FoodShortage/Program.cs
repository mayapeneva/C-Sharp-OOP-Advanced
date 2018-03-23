using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var buyers = new List<IBuyer>();
        var factory = new BuyersFactory();

        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            buyers.Add(factory.CreateBuyer(input));
        }

        string line;
        while ((line = Console.ReadLine()) != "End")
        {
            var buyer = buyers.FirstOrDefault(b => b.Name.Equals(line));
            buyer?.BuyFood();
        }

        Console.WriteLine(buyers.Sum(b => b.Food));
    }
}