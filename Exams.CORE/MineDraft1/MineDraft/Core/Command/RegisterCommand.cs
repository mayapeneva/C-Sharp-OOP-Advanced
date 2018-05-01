using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var entityType = base.Arguments[0];
        var args = base.Arguments.Skip(1).ToList();
        if (entityType == "Harvester")
        {
            return base.HarvesterController.Register(args);
        }

        return base.ProviderController.Register(args);
    }
}