using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Waste
{
    public abstract class Waste : IWaste
    {
        private readonly double volumePerKg;
        private readonly double weight;

        protected Waste(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.volumePerKg = volumePerKg;
            this.weight = weight;
        }

        public string Name { get; }
        public double VolumePerKg => this.volumePerKg;
        public double Weight => this.weight;
        public double TotalVolume => this.weight * this.volumePerKg;
    }
}