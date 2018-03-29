using System;

public class StartUp
{
    public static void Main()
    {
        var coffeeMachine = new CoffeeMachine();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split();
            if (tokens.Length == 1)
            {
                coffeeMachine.InsertCoin(tokens[0]);
            }
            else
            {
                coffeeMachine.BuyCoffee(tokens[0], tokens[1]);
            }
        }

        foreach (var coffeeType in coffeeMachine.CoffeesSold)
        {
            Console.WriteLine(coffeeType);
        }
    }
}