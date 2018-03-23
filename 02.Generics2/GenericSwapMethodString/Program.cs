using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var box = new Box<string>();
        for (int i = 0; i < n; i++)
        {
            box.Add(Console.ReadLine());
        }

        var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        box.Swap(indexes[0], indexes[1]);

        Console.WriteLine(box.ToString());
    }
}