using System.Collections.Generic;

namespace CollectionHierarchy_EXER.Interfaces
{
    public interface ICollectable
    {
        List<string> Collection { get; set; }

        int AddItem(string itemToAdd);
    }
}