using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private int coins;
    private readonly List<CoffeeType> coffeeSold;

    public CoffeeMachine()
    {
        this.coffeeSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold
    {
        get { return this.coffeeSold; }
    }

    public void BuyCoffee(string size, string type)
    {
        var currentPrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
        var currentType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);
        if ((int)currentPrice <= this.coins)
        {
            this.coffeeSold.Add(currentType);
            this.coins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        var c = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coins += (int)c;
    }
}