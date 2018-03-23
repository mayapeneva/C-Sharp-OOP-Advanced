using System;

public class Program
{
    public static void Main()
    {
        var nameAndAddress = Console.ReadLine().Split();
        var name = $"{nameAndAddress[0]} {nameAndAddress[1]}";
        var address = nameAndAddress[2];
        var town = nameAndAddress[3];
        var tuple1 = new Threeuple<string, string, string>(name, address, town);

        var nameAndBeer = Console.ReadLine().Split();
        var name2 = nameAndBeer[0];
        var beerLitres = int.Parse(nameAndBeer[1]);
        var drinkOrNot = nameAndBeer[2].Equals("drunk");
        var tuple2 = new Threeuple<string, int, bool>(name2, beerLitres, drinkOrNot);

        var bankDetails = Console.ReadLine().Split();
        var name3 = bankDetails[0];
        var bankBalance = double.Parse(bankDetails[1]);
        var bankName = bankDetails[2];

        var tuple3 = new Threeuple<string, double, string>(name3, bankBalance, bankName);

        Console.WriteLine(tuple1.ToString());
        Console.WriteLine(tuple2.ToString());
        Console.WriteLine(tuple3.ToString());
    }
}