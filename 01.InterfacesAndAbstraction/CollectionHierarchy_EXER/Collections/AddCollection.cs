using CollectionHierarchy_EXER.Interfaces;

namespace CollectionHierarchy_EXER.Collections
{
    public class AddCollection : Collections
    {
        public override int AddItem(string itemToAdd)
        {
            this.Collection.Add(itemToAdd);
            return this.Collection.Count - 1;
        }
    }
}