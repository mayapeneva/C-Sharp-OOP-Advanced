using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    public QuitCommand(List<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.GenerateReport();
    }
}