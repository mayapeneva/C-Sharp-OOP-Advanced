using RecyclingStation.Core;
using RecyclingStation.Models.DisposalStrategies;

namespace RecyclingStation
{
    public class RecyclingStationMain
    {
        public static void Main()
        {
            var strategyHolder = new StrategyHolder();
            var garbageProcessor = new GarbageProcessor(strategyHolder);
            var recyclingStationManager = new RecyclingStationManager(garbageProcessor);
            var processStarter = new ProcessStarter(recyclingStationManager);
            processStarter.Start();
        }
    }
}