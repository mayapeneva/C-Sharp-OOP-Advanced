using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    public ShutdownCommand(List<string> arguments)
        : base(arguments)
    {
    }

    [RefreshEntities]
    public IHarvesterController HarvesterController { get; private set; }

    [RefreshEntities]
    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        var result = new StringBuilder();
        result.AppendLine(string.Format(Constants.Shutdown));
        result.AppendLine(string.Format(Constants.TotalEnergyProduced, this.ProviderController.TotalEnergyProduced));
        result.AppendLine(string.Format(Constants.TotalMinedOre, this.HarvesterController.OreProduced));

        return result.ToString().Trim();
    }
}