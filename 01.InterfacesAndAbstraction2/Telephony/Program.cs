using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var numbersToCall = Console.ReadLine().Split();
        var sitesToBrowse = Console.ReadLine().Split();

        var phone = new Smartphone();
        foreach (var number in numbersToCall)
        {
            Console.WriteLine(number.Any(d => !char.IsDigit(d)) ? "Invalid number!" : $"{phone.Call()}{number}");
        }

        foreach (var site in sitesToBrowse)
        {
            Console.WriteLine(site.Any(char.IsDigit) ? "Invalid URL!" : $"{phone.Browse()}{site}!");
        }
    }
}