using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var lake = new Lake<int>(input);
        Console.WriteLine(string.Join(", ", lake));
    }
}