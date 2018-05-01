using System.Collections.Generic;

public class RepairCommand : Command
{
    public RepairCommand(List<string> arguments)
        : base(arguments)
    {
    }

    [RefreshEntities]
    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        var value = double.Parse(base.Arguments[0]);
        return this.ProviderController.Repair(value);
    }
}