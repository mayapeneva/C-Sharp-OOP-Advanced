using LambdaCore_Skeleton.Interfaces;

namespace LambdaCore_Skeleton.Commands
{
    public class SelectCoreCommand : ICommand
    {
        private const string SuccessfullMessage = "Currently selected Core {0}!";
        private const string FailureMessage = "Failed to select Core {0}!";

        private readonly char coreName;

        public SelectCoreCommand(char coreName)
        {
            this.coreName = coreName;
        }

        public string Execute(ICoreManager coreManager)
        {
            var result = coreManager.SelectCore(this.coreName);
            if (result)
            {
                return string.Format(SuccessfullMessage, this.coreName);
            }

            return string.Format(FailureMessage, this.coreName);
        }
    }
}