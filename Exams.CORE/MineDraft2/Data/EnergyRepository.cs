public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; private set; }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        if (energyNeeded <= this.EnergyStored)
        {
            this.EnergyStored -= energyNeeded;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"Total Energy Produced: {this.EnergyStored}";
    }
}