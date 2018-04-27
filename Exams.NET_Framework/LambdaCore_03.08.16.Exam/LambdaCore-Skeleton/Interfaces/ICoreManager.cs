namespace LambdaCore_Skeleton.Interfaces
{
    public interface ICoreManager
    {
        char AddCore(ICore core);

        bool RemoveCore(char coreName);

        bool SelectCore(char coreName);

        char AttachFragment(IFragment fragment);

        string[] DetachFragment();
    }
}