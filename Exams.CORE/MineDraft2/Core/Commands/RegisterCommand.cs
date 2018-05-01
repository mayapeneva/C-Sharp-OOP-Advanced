using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private const string HarvesterName = "Harvester";

    public RegisterCommand(List<string> arguments)
        : base(arguments)
    {
    }

    [RefreshEntities]
    public IHarvesterController HarvesterController { get; private set; }

    [RefreshEntities]
    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        var entityType = base.Arguments[0];
        var args = base.Arguments.Skip(1).ToList();
        if (entityType.Equals(HarvesterName))
        {
            return this.HarvesterController.Register(args);
        }

        return this.ProviderController.Register(args);
    }
}