namespace RecyclingStation.WasteDisposal.Models.Waste
{
    using Interfaces;

    public abstract class Garbage : IWaste
    {
        protected Garbage(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.Weight = weight;
            this.VolumePerKg = volumePerKg;
        }

        public string Name { get; }

        public double Weight { get; }

        public double VolumePerKg { get; }
    }
}