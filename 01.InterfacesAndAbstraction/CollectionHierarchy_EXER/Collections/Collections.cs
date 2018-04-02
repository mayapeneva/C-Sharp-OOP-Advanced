using CollectionHierarchy_EXER.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy_EXER.Collections
{
    public abstract class Collections : IAddable, ICollectable
    {
        protected Collections()
        {
            this.Collection = new List<string>(100);
        }

        public List<string> Collection { get; set; }

        public virtual int AddItem(string itemToAdd)
        {
            this.Collection.Insert(0, itemToAdd);
            return 0;
        }
    }
}