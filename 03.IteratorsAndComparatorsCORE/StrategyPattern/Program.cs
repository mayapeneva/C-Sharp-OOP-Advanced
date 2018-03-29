using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var peopleByName = new SortedSet<Person>();
        var peopleByAge = new SortedSet<Person>(new AgeComparator());

        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);
            var person = new Person(name, age);

            peopleByName.Add(person);
            peopleByAge.Add(person);
        }

        foreach (var person in peopleByName)
        {
            Console.WriteLine(person);
        }

        foreach (var person in peopleByAge)
        {
            Console.WriteLine(person);
        }
    }
}