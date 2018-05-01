using System.Collections.Generic;

public class ItemCommand : AbstractCommand
{
    public ItemCommand(List<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.AddItemToHero(base.Arguments);
    }
}