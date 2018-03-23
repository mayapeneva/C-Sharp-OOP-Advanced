using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var beings = new List<IBeing>();
        var factory = new InhabitantFactory();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var being = factory.CreateBeing(input.Split());
            if (being != null)
            {
                beings.Add(being);
            }
        }

        var year = Console.ReadLine();
        foreach (var being in beings.Where(b => b.Birthdate.EndsWith(year)))
        {
            Console.WriteLine(being.Birthdate);
        }
    }
}