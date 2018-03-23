using System.Collections.ObjectModel;
using CollectionHierarchy_EXER.Interfaces;

namespace CollectionHierarchy_EXER.Collections
{
    public class MyList : Collections, IRemovable, ICountable
    {
        public int Used => this.Collection.Count;

        public string RemoveItem()
        {
            var item = this.Collection[0];
            this.Collection.RemoveAt(0);
            return item;
        }

        public int CountElements()
        {
            return this.Used;
        }
    }
}