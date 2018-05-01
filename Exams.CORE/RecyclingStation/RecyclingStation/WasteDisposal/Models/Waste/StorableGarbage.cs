namespace RecyclingStation.WasteDisposal.Models.Waste
{
    using RecyclingStation.WasteDisposal.Attributes;

    [Storable]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double weight, double volumePerKg)
            : base(name, weight, volumePerKg)
        {
        }
    }
}