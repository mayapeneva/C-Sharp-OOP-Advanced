using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(List<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.AddHero(base.Arguments);
    }
}