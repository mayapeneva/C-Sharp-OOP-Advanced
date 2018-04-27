using System;
using System.Collections.Generic;
using System.Linq;

public class ExtendedDatabase
{
    private const int DefaultCapacity = 16;

    private List<Person> collection;

    public ExtendedDatabase(params Person[] items)
    {
        this.Collection = new List<Person>(items);
    }

    public List<Person> Collection
    {
        get => this.collection;
        private set
        {
            if (value.Count > DefaultCapacity)
            {
                throw new InvalidOperationException();
            }

            this.collection = value;
        }
    }

    public int Count => this.Collection.Count;

    public void Add(Person person)
    {
        if (this.Count >= DefaultCapacity
            || this.collection.Any(p => p.Username.Equals(person.Username))
            || this.collection.Any(p => p.Id.Equals(person.Id)))
        {
            throw new InvalidOperationException();
        }

        this.Collection.Add(person);
    }

    public void Remove()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        this.Collection[this.Count - 1] = null;
    }

    public Person FindByUsername(string username)
    {
        if (username == null)
        {
            throw new ArgumentNullException();
        }

        if (!this.collection.Any(p => p.Username.Equals(username)))
        {
            throw new InvalidOperationException();
        }

        return this.collection.First(p => p.Username.Equals(username));
    }

    public Person FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentException();
        }

        if (!this.collection.Any(p => p.Id.Equals(id)))
        {
            throw new InvalidOperationException();
        }

        return this.collection.First(p => p.Id.Equals(id));
    }

    public List<Person> Fetch()
    {
        return this.collection;
    }
}