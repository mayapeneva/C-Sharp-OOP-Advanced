namespace RecyclingStation.WasteDisposal.Interfaces
{
    public interface IRecyclingStationManager
    {
        string ProcessGarbage(string name, double volumePerKg, double weight, string type);

        string Status();

        string ChangeManagementRequirement(double energyBalance, double capitalBalance, string type);
    }
}