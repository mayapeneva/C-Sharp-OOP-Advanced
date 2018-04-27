using LambdaCore_Skeleton.Interfaces;

namespace LambdaCore_Skeleton.Commands
{
    public class RemoveCoreCommand : ICommand
    {
        private const string SuccessfullMessage = "Successfully removed Core {0}!";
        private const string FailureMessage = "Failed to remove Core {0}!";

        private readonly char coreName;

        public RemoveCoreCommand(char coreName)
        {
            this.coreName = coreName;
        }

        public string Execute(ICoreManager coreManager)
        {
            var ifCoreExists = coreManager.RemoveCore(this.coreName);
            if (ifCoreExists)
            {
                return string.Format(SuccessfullMessage, this.coreName);
            }

            return string.Format(FailureMessage, this.coreName);
        }
    }
}