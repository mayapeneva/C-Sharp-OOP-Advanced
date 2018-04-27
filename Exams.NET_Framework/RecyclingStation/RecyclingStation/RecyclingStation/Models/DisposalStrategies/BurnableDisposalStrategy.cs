using RecyclingStation.WasteDisposal.DisposalStrategies;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.DisposalStrategies
{
    public class BurnableDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateEnergy(IWaste garbage)
        {
            return garbage.TotalVolume * 0.8;
        }

        protected override double CalculateCapital(IWaste garbage)
        {
            return 0;
        }
    }
}