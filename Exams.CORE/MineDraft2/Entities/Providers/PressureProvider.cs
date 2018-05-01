public class PressureProvider : Provider
{
    private const int DurabilityDecreaser = 300;
    private const int EnergyMultiplier = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability -= DurabilityDecreaser;
        this.EnergyOutput *= EnergyMultiplier;
    }
}