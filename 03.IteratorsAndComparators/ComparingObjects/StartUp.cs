using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var people = new List<Person>();
            while (input[0] != "END")
            {
                people.Add(new Person(input[0], int.Parse(input[1]), input[2]));

                input = Console.ReadLine().Split();
            }

            var n = int.Parse(Console.ReadLine());
            var thePerson = people[n - 1];

            var equals = people.Count(p => p.CompareTo(thePerson) == 0);
            if (equals == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.Write($"{equals} ");
                Console.Write($"{people.Count - equals} ");
                Console.WriteLine(people.Count);
            }
        }
    }
}