using System;
using System.Collections.Generic;

public class ListIterator
{
    private List<string> collection;
    private int currentIndex;

    public ListIterator(List<string> collection)
    {
        this.Collection = collection;
        this.currentIndex = 0;
    }

    public List<string> Collection
    {
        get => this.collection;
        private set
        {
            if (value.Count == 0 || value == null)
            {
                throw new ArgumentNullException();
            }

            this.collection = value;
        }
    }

    public bool HasNext()
    {
        return this.currentIndex < this.collection.Count - 1;
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.currentIndex++;
            return true;
        }

        return false;
    }

    public string Print()
    {
        if (this.collection.Count > 0)
        {
            return this.collection[this.currentIndex];
        }

        return string.Empty;
    }
}