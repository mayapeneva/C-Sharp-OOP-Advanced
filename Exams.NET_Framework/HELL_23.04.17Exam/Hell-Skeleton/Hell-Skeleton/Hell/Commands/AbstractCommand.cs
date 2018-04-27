public abstract class AbstractCommand : ICommand
{
    protected AbstractCommand(IManager heroManager, string name)
    {
        this.Name = name;
        this.HeroManager = heroManager;
    }

    public string Name { get; }

    public IManager HeroManager { get; }

    public abstract string Execute();
}