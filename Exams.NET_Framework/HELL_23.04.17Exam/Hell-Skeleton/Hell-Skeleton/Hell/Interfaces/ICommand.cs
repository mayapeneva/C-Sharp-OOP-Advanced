public interface ICommand
{
    string Name { get; }
    IManager HeroManager { get; }

    string Execute();
}