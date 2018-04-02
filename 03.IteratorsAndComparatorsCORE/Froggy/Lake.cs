using System.Collections;
using System.Collections.Generic;

public class Lake<T> : IEnumerable<T>
{
    private readonly List<T> collection;

    public Lake(params T[] collection)
    {
        this.collection = new List<T>(collection);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.collection.Count; i += 2)
        {
            yield return this.collection[i];
        }

        var staringIndex = this.collection.Count % 2 == 0 ? this.collection.Count - 1 : this.collection.Count - 2;
        for (int j = staringIndex; j >= 0; j -= 2)
        {
            yield return this.collection[j];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}