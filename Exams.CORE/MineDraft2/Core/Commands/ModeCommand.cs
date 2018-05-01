using System.Collections.Generic;

public class ModeCommand : Command
{
    public ModeCommand(List<string> arguments)
        : base(arguments)
    {
    }

    [RefreshEntities]
    public IHarvesterController HarvesterController { get; private set; }

    public override string Execute()
    {
        var mode = base.Arguments[0];
        return this.HarvesterController.ChangeMode(mode);
    }
}