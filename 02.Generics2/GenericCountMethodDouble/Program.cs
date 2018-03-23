using System;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var box = new Box<double>();
        for (int i = 0; i < n; i++)
        {
            box.Add(double.Parse(Console.ReadLine()));
        }

        var item = double.Parse(Console.ReadLine());
        Console.WriteLine(box.CountGreaterItems(item));
    }
}