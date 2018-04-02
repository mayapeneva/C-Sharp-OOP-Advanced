using CollectionHierarchy_EXER.Collections;
using CollectionHierarchy_EXER.Interfaces;
using System;

namespace CollectionHierarchy_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var itemsToAdd = Console.ReadLine().Split();
            AddItemsMethod(addCollection, itemsToAdd);
            AddItemsMethod(addRemoveCollection, itemsToAdd);
            AddItemsMethod(myList, itemsToAdd);

            var numberToRemove = int.Parse(Console.ReadLine());
            RemoveItemsMethod(addRemoveCollection, numberToRemove);
            RemoveItemsMethod(myList, numberToRemove);
        }

        private static void AddItemsMethod(ICollectable collection, string[] itemsToAdd)
        {
            foreach (var itemToAdd in itemsToAdd)
            {
                Console.Write(collection.AddItem(itemToAdd) + " ");
            }
            Console.WriteLine();
        }

        private static void RemoveItemsMethod(IRemovable collection, int numberToRemove)
        {
            for (int i = 0; i < numberToRemove; i++)
            {
                Console.Write(collection.RemoveItem() + " ");
            }
            Console.WriteLine();
        }
    }
}