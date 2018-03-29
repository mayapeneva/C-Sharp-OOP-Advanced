using System;
using System.Collections.Generic;

namespace StrategyPattern_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var sortedByNamesSet = new SortedSet<Person>();
            var sortedByAgeSet = new SortedSet<Person>(new AgeComparator());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);
                sortedByNamesSet.Add(person);
                sortedByAgeSet.Add(person);
            }

            foreach (var person in sortedByNamesSet)
            {
                Console.WriteLine(person);
            }

            foreach (var person in sortedByAgeSet)
            {
                Console.WriteLine(person);
            }
        }
    }
}