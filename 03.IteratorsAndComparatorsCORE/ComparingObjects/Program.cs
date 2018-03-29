using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var people = new List<Person>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split();
            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var town = tokens[2];
            people.Add(new Person(name, age, town));
        }

        var index = int.Parse(Console.ReadLine());
        var personToCompare = people[index - 1];

        var equalPeopleCount = 0;
        foreach (var person in people)
        {
            if (personToCompare.CompareTo(person) == 0)
            {
                equalPeopleCount++;
            }
        }

        Console.WriteLine(equalPeopleCount == 1
            ? "No matches"
            : $"{equalPeopleCount} {people.Count - equalPeopleCount} {people.Count}");
    }
}