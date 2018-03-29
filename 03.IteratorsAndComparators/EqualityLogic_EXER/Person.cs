using System;
using System.Linq;

namespace EqualityLogic_EXER
{
    public class Person : IEquatable<Person>, IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public bool Equals(Person other)
        {
            var result = this.name.Equals(other.name);
            if (!result)
            {
                return result;
            }

            return this.age.Equals(other.age);
        }

        public int CompareTo(Person other)
        {
            var result = String.Compare(this.name, other.name, StringComparison.InvariantCulture);
            if (result != 0)
            {
                return result;
            }

            return this.age.CompareTo(other.age);
        }

        public override int GetHashCode()
        {
            var hashCode = this.name.Length * 10000;
            hashCode = this.name.Aggregate(hashCode, (current, letter) => current + letter);
            hashCode += this.age * 10000;

            return hashCode;
        }
    }
}