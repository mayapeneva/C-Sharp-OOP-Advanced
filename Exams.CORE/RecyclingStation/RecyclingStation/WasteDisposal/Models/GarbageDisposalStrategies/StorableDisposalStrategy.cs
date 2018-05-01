namespace RecyclingStation.WasteDisposal.Models.GarbageDisposalStrategies
{
    using Attributes;
    using Interfaces;
    using ProcessingData;

    [Storable]
    public class StorableDisposalStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energy = -((garbage.VolumePerKg * garbage.Weight) * 13 / 100);
            var capital = -((garbage.VolumePerKg * garbage.Weight) * 65 / 100);

            var data = new ProcessingData();
            data.IncreaseEnergyBalance(energy);
            data.IncreaseCapitalBalance(capital);

            return data;
        }
    }
}