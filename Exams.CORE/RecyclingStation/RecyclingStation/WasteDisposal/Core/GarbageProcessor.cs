namespace RecyclingStation.WasteDisposal.Core
{
    using Attributes;
    using Interfaces;
    using IO;
    using Models;
    using Models.GarbageDisposalStrategies;
    using System;
    using System.Linq;

    public class GarbageProcessor : IGarbageProcessor
    {
        private ManagementRequirment managementRequirement;

        public GarbageProcessor(IProcessingData processingData, IStrategyHolder strategyHolder)
        {
            this.ProcessingData = processingData;
            this.StrategyHolder = new StrategyHolder();

            this.InitialiseStrategyHoder();
        }

        public IProcessingData ProcessingData { get; set; }
        public IStrategyHolder StrategyHolder { get; }

        private void InitialiseStrategyHoder()
        {
            this.StrategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableDisposalStrategy());
            this.StrategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableDisposalStrategy());
            this.StrategyHolder.AddStrategy(typeof(StorableAttribute), new StorableDisposalStrategy());
        }

        public string ProcessWaste(IWaste garbage)
        {
            Type type = garbage.GetType();
            DisposableAttribute disposalAttribute = (DisposableAttribute)type.GetCustomAttributes(true).FirstOrDefault();

            this.StrategyHolder.GetDisposalStrategies.TryGetValue(disposalAttribute.GetType(), out var currentStrategy);

            if (this.managementRequirement != null && this.StoppedGarbage(garbage) && this.UnsifficientBalances(garbage))
            {
                return string.Format(OutpuMessages.ProcessingDenied);
            }

            var data = currentStrategy.ProcessGarbage(garbage);
            this.ProcessingData.IncreaseCapitalBalance(data.CapitalBalance);
            this.ProcessingData.IncreaseEnergyBalance(data.EnergyBalance);

            return string.Format(OutpuMessages.GarbageProcessed, garbage.Weight, garbage.Name);
        }

        private bool StoppedGarbage(IWaste garbage)
        {
            return garbage.GetType().Name.ToString() == (this.managementRequirement.GarbageType + "Garbage");
        }

        private bool UnsifficientBalances(IWaste garbage)
        {
            return this.ProcessingData.EnergyBalance < this.managementRequirement.EnergyBalance
                || this.ProcessingData.CapitalBalance < this.managementRequirement.CapitaBalance;
        }

        public void ChangeMangementRequirement(ManagementRequirment requirement)
        {
            this.managementRequirement = requirement;
        }
    }
}