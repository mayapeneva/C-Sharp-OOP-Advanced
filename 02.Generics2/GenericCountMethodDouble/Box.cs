using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box<T>
    where T : IComparable
{
    private List<T> collection;

    public Box()
    {
        this.collection = new List<T>();
    }

    public void Add(T item)
    {
        this.collection.Add(item);
    }

    public int CountGreaterItems(T item)
    {
        return this.collection.Count(i => i.CompareTo(item) > 0);
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        foreach (var item in this.collection)
        {
            result.AppendLine($"{item.GetType().FullName}: {item}");
        }
        return result.ToString().Trim();
    }
}