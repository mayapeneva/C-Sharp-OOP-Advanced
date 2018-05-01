using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    public InspectCommand(List<string> arguments)
        : base(arguments)
    {
    }

    [RefreshEntities]
    public IHarvesterController HarvesterController { get; private set; }

    [RefreshEntities]
    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        var id = int.Parse(base.Arguments[0]);
        if (this.HarvesterController.Entities.Any(e => e.ID.Equals(id)))
        {
            return this.HarvesterController.Entities.First(e => e.ID.Equals(id)).ToString();
        }

        if (this.ProviderController.Entities.Any(e => e.ID.Equals(id)))
        {
            return this.ProviderController.Entities.First(e => e.ID.Equals(id)).ToString();
        }

        return string.Format(Constants.NoSuchEntity, id);
    }
}