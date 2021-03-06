﻿using System;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            var result = String.Compare(this.name, other.name, StringComparison.InvariantCulture);
            if (result != 0)
            {
                return result;
            }

            result = this.age.CompareTo(other.age);
            if (result != 0)
            {
                return result;
            }

            result = String.Compare(this.town, other.town, StringComparison.InvariantCulture);
            if (result != 0)
            {
                return result;
            }

            return 0;
        }
    }
}