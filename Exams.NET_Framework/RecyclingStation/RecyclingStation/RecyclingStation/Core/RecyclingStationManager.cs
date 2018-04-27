using RecyclingStation.Models.ProcessingData;
using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace RecyclingStation.Core
{
    public class RecyclingStationManager : IRecyclingStationManager
    {
        private const string garbageSuffix = "Garbage";

        private readonly IGarbageProcessor garbageProcessor;
        private IProcessingData processingData;

        private double totalEnergy;
        private double totalCapital;

        private double requiredMinEnergy;
        private double requiredMinCapital;
        private string deniedWasteType;

        public RecyclingStationManager(IGarbageProcessor garbageProcessor)
        {
            this.garbageProcessor = garbageProcessor;
            this.processingData = new ProcessingData();
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            if (type == this.deniedWasteType
                && (this.totalEnergy < this.requiredMinEnergy
                || this.totalCapital < this.requiredMinCapital))
            {
                return "Processing Denied!";
            }

            var garbageTypeName = type + garbageSuffix;
            var garbageType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name.Equals(garbageTypeName));

            var waste = (IWaste)Activator.CreateInstance(garbageType, name, weight, volumePerKg);

            this.processingData = this.garbageProcessor.ProcessWaste(waste);
            this.totalEnergy += this.processingData.EnergyBalance;
            this.totalCapital += this.processingData.CapitalBalance;

            return $"{waste.Weight:f2} kg of {waste.Name} successfully processed!";
        }

        public string Status()
        {
            return $"Energy: {this.totalEnergy:f2} Capital: {this.totalCapital:f2}";
        }

        public string ChangeManagementRequirement(double energyBalance, double capitalBalance, string type)
        {
            this.requiredMinEnergy = energyBalance;
            this.requiredMinCapital = capitalBalance;
            this.deniedWasteType = type;

            return "Management requirement changed!";
        }
    }
}