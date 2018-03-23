using System.Collections.Generic;

public class Collection<T> : IAddCollection<T>, IAddRemoveCollection<T>, IMyList<T>
{
    private List<T> collection;

    public Collection()
    {
        this.collection = new List<T>();
    }

    public int AddFirst(T item)
    {
        this.collection.Insert(0, item);
        return 0;
    }

    public int AddLast(T item)
    {
        this.collection.Add(item);
        return this.collection.Count - 1;
    }

    public T RemoveFirst()
    {
        var itemToRemove = this.collection[0];
        this.collection.RemoveAt(0);
        return itemToRemove;
    }

    public T RemoveLast()
    {
        var itemToRemove = this.collection[this.collection.Count - 1];
        this.collection.RemoveAt(this.collection.Count - 1);
        return itemToRemove;
    }

    public int Used()
    {
        return this.collection.Count;
    }

    int IMyList<T>.AddFirst(T item)
    {
        return this.AddFirst(item);
    }
}