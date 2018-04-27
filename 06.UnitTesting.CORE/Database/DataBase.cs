using System;
using System.Collections.Generic;

public class DataBase
{
    private const int DefaultCapacity = 16;

    private List<int> collection;

    public DataBase(params int[] items)
    {
        this.Collection = new List<int>(items);
    }

    public List<int> Collection
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

    public void Add(int item)
    {
        if (this.Count >= DefaultCapacity)
        {
            throw new InvalidOperationException();
        }

        this.Collection.Add(item);
    }

    public void Remove()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        this.Collection[this.Count - 1] = 0;
    }

    public List<int> Fetch()
    {
        return this.collection;
    }
}