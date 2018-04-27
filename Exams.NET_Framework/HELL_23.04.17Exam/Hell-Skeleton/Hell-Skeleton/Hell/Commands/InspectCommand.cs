public class InspectCommand : AbstractCommand

{
    public InspectCommand(IManager heroManager, string name)
        : base(heroManager, name)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.Inspect(this.Name);
    }
}