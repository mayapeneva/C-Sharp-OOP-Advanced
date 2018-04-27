public abstract class Ammunition : IAmmunition
{
    private string name;
    private double weight;
    private double wearLevel;

    public Ammunition(string name, double weight)
    {
        this.name = name;
        this.weight = weight;
        this.wearLevel = weight * 100;
    }

    public string Name
    {
        get { return this.name; }
    }

    public double WearLevel
    {
        get { return this.wearLevel; }
    }

    public bool WearLevelIsZero { get; set; }
    public int Number { get; set; }

    public void DecreaseWearLevel(double wearAmount)
    {
    }
}