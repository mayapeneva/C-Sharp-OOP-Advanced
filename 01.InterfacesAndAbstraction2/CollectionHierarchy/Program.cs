using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        IAddCollection<string> addCollection = new Collection<string>();
        IAddRemoveCollection<string> addRemoveCollection = new Collection<string>();
        IMyList<string> myListCollection = new Collection<string>();

        var input = Console.ReadLine().Split().ToArray();
        var addResult1 = new List<int>();
        var addResult2 = new List<int>();
        var addResult3 = new List<int>();
        foreach (var item in input)
        {
            addResult1.Add(addCollection.AddLast(item));
            addResult2.Add(addRemoveCollection.AddFirst(item));
            addResult3.Add(myListCollection.AddFirst(item));
        }
        Console.WriteLine(string.Join(" ", addResult1));
        Console.WriteLine(string.Join(" ", addResult2));
        Console.WriteLine(string.Join(" ", addResult3));

        var number = int.Parse(Console.ReadLine());
        var removeResult1 = new List<string>();
        var removeResult2 = new List<string>();
        for (int i = 0; i < number; i++)
        {
            removeResult1.Add(addRemoveCollection.RemoveLast());
            removeResult2.Add(myListCollection.RemoveFirst());
        }
        Console.WriteLine(string.Join(" ", removeResult1));
        Console.WriteLine(string.Join(" ", removeResult2));
    }
}