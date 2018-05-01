using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var id = int.Parse(base.Arguments[0]);
        var sb = new StringBuilder();
        if (base.ProviderController.Entities.Any(e => e.ID.Equals(id)))
        {
            sb.AppendLine(base.ProviderController.Entities.First(e => e.ID.Equals(id)).ToString());
        }
        else if (base.HarvesterController.Entities.Any(e => e.ID.Equals(id)))
        {
            sb.AppendLine(base.HarvesterController.Entities.First(e => e.ID.Equals(id)).ToString());
        }

        if (string.IsNullOrWhiteSpace(sb.ToString()))
        {
            sb.AppendLine($"No entity found with id - {id}");
        }

        return sb.ToString().Trim();
    }
}