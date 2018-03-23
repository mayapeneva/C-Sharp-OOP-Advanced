using System;

public class Program
{
    public static void Main()
    {
        var name = Console.ReadLine();
        ICar car = new Ferrari(name);

        Console.WriteLine($"{car.Model}/{car.UseBrakes()}/{car.PushTheGasPeda()}/{car.Driver}");
    }
}