using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var inhabitans = new List<IInhabitant>();
        var factory = new InhabitantFactory();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            inhabitans.Add(factory.CreateInhabitant(input.Split().ToArray()));
        }

        var idPart = Console.ReadLine();
        foreach (var inhabitant in inhabitans.Where(i => i.Id.EndsWith(idPart)))
        {
            Console.WriteLine(inhabitant.Id);
        }
    }
}