using System;
using System.Collections.Generic;
using System.Linq;

namespace Programm
{
    public class Database
    {
        private const int DefaultCapacity = 16;
        private Person[] people;
        private int currentIndex;

        public Database(IEnumerable<Person> people)
        {
            this.People = people.ToArray();
        }

        public Person[] People
        {
            get => this.people;
            private set
            {
                if (value.Length > 16 || value.Length < 1)
                {
                    throw new InvalidOperationException();
                }

                this.people = new Person[DefaultCapacity];
                var index = 0;

                foreach (var person in value)
                {
                    this.people[index++] = person;
                }

                this.currentIndex = value.Length;
            }
        }

        public int Capacity => DefaultCapacity;
        public int Count => this.currentIndex;

        public void Add(Person person)
        {
            if (this.currentIndex >= DefaultCapacity)
            {
                throw new InvalidOperationException("You cannot add more than 16 people in the database.");
            }

            if (this.people.Any(p => p.Name == person.Name))
            {
                throw new InvalidOperationException("This username already exists");
            }

            if (this.people.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException("This id already exists");
            }

            this.people[this.currentIndex++] = person;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("There are no people left in the database.");
            }

            this.people[this.currentIndex--] = null;
        }

        public Person[] Fetch()
        {
            return this.people.Take(this.currentIndex).ToArray();
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!this.people.Any(p => p.Id.Equals(id)))
            {
                throw new InvalidOperationException("There is no user with this id.");
            }

            return this.people.FirstOrDefault(p => p.Id == id);
        }

        public Person FindByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }

            if (this.people.Any(p => p.Name.Equals(name)))
            {
                return this.people.FirstOrDefault(p => p.Name.Equals(name));
            }

            throw new InvalidOperationException("Theres is no user with this username.");
        }
    }
}