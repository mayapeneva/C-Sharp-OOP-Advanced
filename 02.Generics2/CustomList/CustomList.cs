using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T>
    where T : IComparable<T>
{
    private List<T> collection;

    public CustomList()
    {
        this.collection = new List<T>();
    }

    public void Add(T item)
    {
        this.collection.Add(item);
    }

    public void Remove(int index)
    {
        this.collection.RemoveAt(index);
    }

    public bool Contains(T item)
    {
        return this.collection.Contains(item);
    }

    public void Swap(int indexFrom, int indexTo)
    {
        var swapElement = this.collection[indexFrom];
        this.collection[indexFrom] = this.collection[indexTo];
        this.collection[indexTo] = swapElement;
    }

    public int CountGreaterThan(T item)
    {
        return this.collection.Count(i => i.CompareTo(item) > 0);
    }

    public T Max()
    {
        return this.collection.Max();
    }

    public T Min()
    {
        return this.collection.Min();
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        foreach (var item in this.collection)
        {
            result.AppendLine(item.ToString());
        }
        return result.ToString().Trim();
    }
}