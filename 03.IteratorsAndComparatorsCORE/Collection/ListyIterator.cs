using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    private readonly List<T> collection;
    private int index;

    public ListyIterator()
    {
    }

    public ListyIterator(params T[] collection)
    {
        this.collection = new List<T>(collection);
    }

    public bool Move()
    {
        if (this.index >= this.collection.Count - 1)
        {
            return false;
        }

        this.index++;
        return true;
    }

    public bool HasNext()
    {
        if (this.index >= this.collection.Count - 1)
        {
            return false;
        }

        return true;
    }

    public string Print()
    {
        if (!this.collection.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return this.collection[this.index].ToString();
    }

    public string PrintAll()
    {
        if (!this.collection.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return string.Join(" ", this.collection);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in this.collection)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}