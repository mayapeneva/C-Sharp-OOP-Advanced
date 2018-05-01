namespace RecyclingStation.WasteDisposal.Models
{
    public class ManagementRequirment
    {
        public ManagementRequirment(double energyBalance, double capitalBalance, string garbageType)
        {
            this.EnergyBalance = energyBalance;
            this.CapitaBalance = capitalBalance;
            this.GarbageType = garbageType;
        }

        public double EnergyBalance { get; }
        public double CapitaBalance { get; }
        public string GarbageType { get; }
    }
}