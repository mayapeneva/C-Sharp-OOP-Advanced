using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var soldiers = new List<ISoldier>();
        var factory = new Factory();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var soldier = factory.CreateSoldier(input.Split());
            if (soldier != null)
            {
                soldiers.Add(soldier);
            }
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier.ToString());
        }
    }
}