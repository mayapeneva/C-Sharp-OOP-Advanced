using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var linkedList = new LinkedList<int>();

        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split().ToArray();
            var command = input[0];
            if (command.Equals("Add"))
            {
                linkedList.Add(int.Parse(input[1]));
            }
            else
            {
                linkedList.Remove(int.Parse(input[1]));
            }
        }

        Console.WriteLine(linkedList.Count);
        foreach (var item in linkedList)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
}