using RecyclingStation.WasteDisposal.DisposalStrategies;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.DisposalStrategies
{
    public class StorableDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateEnergy(IWaste garbage)
        {
            return -(garbage.TotalVolume * 0.13);
        }

        protected override double CalculateCapital(IWaste garbage)
        {
            return -(garbage.TotalVolume * 0.65);
        }
    }
}