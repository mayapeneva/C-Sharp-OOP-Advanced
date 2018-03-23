using System.Collections.Generic;
using System.Text;

public class Box<T>
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