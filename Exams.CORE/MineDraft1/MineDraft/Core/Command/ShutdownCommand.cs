using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Produced: {base.ProviderController.TotalEnergyProduced}");
        sb.Append($"Total Mined Plumbus Ore: {base.HarvesterController.OreProduced}");

        return sb.ToString();
    }
}