using System.Collections.Generic;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var value = double.Parse(base.Arguments[0]);
        return base.ProviderController.Repair(value);
    }
}