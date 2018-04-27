using System.Reflection;

namespace RecyclingStation.Core
{
    using System;
    using System.Linq;
    using WasteDisposal.Attributes;
    using WasteDisposal.Interfaces;

    public class GarbageProcessor : IGarbageProcessor
    {
        private const string garbageSuffix = "Garbage";
        private const string strategySuffix = "DisposalStrategy";

        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public IStrategyHolder StrategyHolder { get; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            var attributeType = garbage.GetType();
            var disposalAttribute = (DisposableAttribute)attributeType.GetCustomAttributes(true).First();

            if (disposalAttribute == null)
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            var strategyName = attributeType.Name.Replace(garbageSuffix, strategySuffix);
            var currentStrategyType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(s => s.Name.Equals(strategyName));
            var currentStrategy = (IGarbageDisposalStrategy)Activator.CreateInstance(currentStrategyType);

            if (!this.StrategyHolder.GetDisposalStrategies.ContainsKey(attributeType))
            {
                this.StrategyHolder.AddStrategy(attributeType, currentStrategy);
            }

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}