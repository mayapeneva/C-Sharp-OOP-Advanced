public abstract class Ammunition : IAmmunition
{
    private const int WearLevelIncreaser = 100;

    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = this.Weight * WearLevelIncreaser;
    }

    public string Name { get; }
    public double Weight { get; }
    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }

    public void ReChargeAmmunition()
    {
        this.WearLevel = this.Weight * WearLevelIncreaser;
    }
}