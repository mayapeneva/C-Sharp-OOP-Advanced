using RecyclingStation.WasteDisposal.DisposalStrategies;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.DisposalStrategies
{
    public class RecyclableDisposalStrategy : GarbageDisposalStrategy

    {
        protected override double CalculateEnergy(IWaste garbage)
        {
            return -(garbage.TotalVolume * 0.5);
        }

        protected override double CalculateCapital(IWaste garbage)
        {
            return 400 * garbage.Weight;
        }
    }
}