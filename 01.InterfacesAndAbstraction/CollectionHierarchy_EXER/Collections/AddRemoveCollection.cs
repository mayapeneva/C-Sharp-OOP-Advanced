using CollectionHierarchy_EXER.Interfaces;

namespace CollectionHierarchy_EXER.Collections
{
    public class AddRemoveCollection : Collections, IRemovable
    {
        public string RemoveItem()
        {
            var index = this.Collection.Count - 1;
            var item = this.Collection[index];
            this.Collection.RemoveAt(index);
            return item;
        }
    }
}