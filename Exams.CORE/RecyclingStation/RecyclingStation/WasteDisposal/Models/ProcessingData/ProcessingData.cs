namespace RecyclingStation.WasteDisposal.Models.ProcessingData
{
    using Interfaces;

    public class ProcessingData : IProcessingData
    {
        public double EnergyBalance { get; private set; }

        public double CapitalBalance { get; private set; }

        public void IncreaseCapitalBalance(double capital)
        {
            this.CapitalBalance += capital;
        }

        public void IncreaseEnergyBalance(double energy)
        {
            this.EnergyBalance += energy;
        }
    }
}