using System;

public class Program
{
    public static void Main()
    {
        var spi = new StreamProgressInfo(new Music("Pearls Of Passion", "Roxette", 60, 37));
        Console.WriteLine(spi.CalculateCurrentPercent());
    }
}