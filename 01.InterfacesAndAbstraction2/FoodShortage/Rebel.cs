public class Rebel : IBuyer
{
    public const int FoodIncrease = 5;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }

    public string Name { get; }
    public int Age { get; }
    public string Group { get; }
    public int Food { get; private set; }

    public void BuyFood()
    {
        this.Food += FoodIncrease;
    }
}