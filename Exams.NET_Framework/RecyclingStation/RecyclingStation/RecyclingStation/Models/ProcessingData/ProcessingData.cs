using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.ProcessingData
{
    public class ProcessingData : IProcessingData
    {
        public double EnergyBalance { get; set; }

        public double CapitalBalance { get; set; }
    }
}