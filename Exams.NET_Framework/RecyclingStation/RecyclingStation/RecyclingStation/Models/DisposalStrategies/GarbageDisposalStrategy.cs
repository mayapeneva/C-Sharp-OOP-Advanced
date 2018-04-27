using RecyclingStation.Models.ProcessingData;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.DisposalStrategies
{
    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        private readonly IProcessingData processingData;

        protected GarbageDisposalStrategy()
        {
            this.processingData = new ProcessingData();
        }

        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            this.processingData.EnergyBalance = this.CalculateEnergy(garbage);
            this.processingData.CapitalBalance = this.CalculateCapital(garbage);
            return this.processingData;
        }

        protected abstract double CalculateEnergy(IWaste garbage);

        protected abstract double CalculateCapital(IWaste garbage);
    }
}