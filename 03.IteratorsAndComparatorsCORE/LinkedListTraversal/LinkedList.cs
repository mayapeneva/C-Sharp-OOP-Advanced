using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private readonly List<T> collection;

    public LinkedList()
    {
        this.collection = new List<T>();
    }

    public int Count => this.collection.Count;

    public void Add(T item)
    {
        this.collection.Add(item);
    }

    public void Remove(T item)
    {
        var index = this.collection.FindIndex(i => i.Equals(item));
        if (index >= 0 && index < this.Count - 1)
        {
            this.collection.RemoveAt(index);
        }
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