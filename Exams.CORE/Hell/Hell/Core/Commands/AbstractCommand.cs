using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    protected AbstractCommand(List<string> arguments, IManager manager)
    {
        this.Arguments = arguments;
        this.Manager = manager;
    }

    public List<string> Arguments { get; }
    public IManager Manager { get; }

    public abstract string Execute();
}