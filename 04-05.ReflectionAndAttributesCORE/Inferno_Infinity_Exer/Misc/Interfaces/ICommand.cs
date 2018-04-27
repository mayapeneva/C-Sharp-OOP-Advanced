public interface ICommand
{
    void Execute(string[] args, Repository repository);
}