using LambdaCore_Skeleton.Interfaces;

namespace LambdaCore_Skeleton.Commands
{
    public class DetachFragment : ICommand
    {
        private const string SuccessfullMessage = "“Successfully detached Fragment {0} from Core {1}!";
        private const string FailureMessage = "Failed to detach Fragment!";

        public string Execute(ICoreManager coreManager)
        {
            var result = coreManager.DetachFragment();
            if (result == default(string[]))
            {
                return FailureMessage;
            }

            return string.Format(SuccessfullMessage, result[1], result[0]);
        }
    }
}