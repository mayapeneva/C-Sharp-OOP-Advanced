public abstract class Ammunition : IAmmunition
{
    private const double InitialWearLevelIncreaser = 100;

    private double weight;

    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public string Name { get; }
    public double Weight { get; }

    public double WearLevel
    {
        get => this.weight;
        private set => this.weight = value * InitialWearLevelIncreaser;
    }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}