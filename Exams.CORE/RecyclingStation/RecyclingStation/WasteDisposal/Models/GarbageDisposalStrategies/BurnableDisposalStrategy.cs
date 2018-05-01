namespace RecyclingStation.WasteDisposal.Models.GarbageDisposalStrategies
{
    using Attributes;
    using Interfaces;
    using ProcessingData;

    [Burnable]
    public class BurnableDisposalStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energy = (garbage.VolumePerKg * garbage.Weight) * 80 / 100;

            var data = new ProcessingData();
            data.IncreaseEnergyBalance(energy);

            return data;
        }
    }
}