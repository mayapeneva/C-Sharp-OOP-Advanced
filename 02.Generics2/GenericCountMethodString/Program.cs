using System;

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

        var item = Console.ReadLine();
        Console.WriteLine(box.CountGreaterItems(item));
    }
}