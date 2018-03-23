using System;

public class Program
{
    public static void Main()
    {
        var nameAndAddress = Console.ReadLine().Split();
        var name = $"{nameAndAddress[0]} {nameAndAddress[1]}";
        var address = nameAndAddress[2];
        var tuple1 = new Tuple<string, string>(name, address);

        var nameAndBeer = Console.ReadLine().Split();
        var name2 = nameAndBeer[0];
        var beerLitres = int.Parse(nameAndBeer[1]);
        var tuple2 = new Tuple<string, int>(name2, beerLitres);

        var intAndDbl = Console.ReadLine().Split();
        var intNum = int.Parse(intAndDbl[0]);
        var doubleNum = double.Parse(intAndDbl[1]);
        var tuple3 = new Tuple<int, double>(intNum, doubleNum);

        Console.WriteLine(tuple1.ToString());
        Console.WriteLine(tuple2.ToString());
        Console.WriteLine(tuple3.ToString());
    }
}