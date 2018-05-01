namespace RecyclingStation.WasteDisposal.Models.GarbageDisposalStrategies
{
    using Attributes;
    using Interfaces;
    using ProcessingData;

    [Recyclable]
    public class RecyclableDisposalStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energy = -((garbage.VolumePerKg * garbage.Weight) * 50 / 100);
            var capital = 400 * garbage.Weight;

            var data = new ProcessingData();
            data.IncreaseEnergyBalance(energy);
            data.IncreaseCapitalBalance(capital);

            return data;
        }
    }
}