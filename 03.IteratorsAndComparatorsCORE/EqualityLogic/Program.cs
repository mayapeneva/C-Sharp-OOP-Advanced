using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var peopleSorted = new SortedSet<Person>();
        var peopleByInsertion = new HashSet<Person>();

        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);
            var person = new Person(name, age);

            peopleSorted.Add(person);
            peopleByInsertion.Add(person);
        }

        Console.WriteLine(peopleSorted.Count);
        Console.WriteLine(peopleByInsertion.Count);
    }
}