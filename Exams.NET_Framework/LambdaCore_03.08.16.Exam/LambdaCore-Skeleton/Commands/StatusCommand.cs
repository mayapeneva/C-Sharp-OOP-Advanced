using LambdaCore_Skeleton.Interfaces;

namespace LambdaCore_Skeleton.Commands
{
    public class StatusCommand : ICommand
    {
        public string Execute(ICoreManager coreManager)
        {
            return coreManager.ToString();
        }
    }
}