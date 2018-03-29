using System;

namespace StrategyPattern_EXER
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }
        public int Age { get; }

        public int CompareTo(Person other)
        {
            var result = this.Name.Length.CompareTo(other.Name.Length);
            if (result != 0)
            {
                return result;
            }

            var firstName = this.Name.ToLower();
            var secondName = other.Name.ToLower();
            return firstName[0].CompareTo(secondName[0]);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}