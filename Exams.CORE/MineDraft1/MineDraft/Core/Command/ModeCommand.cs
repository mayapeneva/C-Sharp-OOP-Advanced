using System.Collections.Generic;

public class ModeCommand : Command
{
    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var mode = base.Arguments[0];
        return base.HarvesterController.ChangeMode(mode);
    }
}