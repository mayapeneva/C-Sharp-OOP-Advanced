using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    private readonly List<T> collection;

    public Stack()
    {
        this.collection = new List<T>();
    }

    public void Push(T item)
    {
        this.collection.Add(item);
    }

    public void Pop()
    {
        if (!this.collection.Any())
        {
            throw new InvalidOperationException("No elements");
        }

        this.collection.RemoveAt(this.collection.Count - 1);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.collection.Count - 1; i >= 0; i--)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}