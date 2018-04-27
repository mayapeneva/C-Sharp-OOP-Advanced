using LambdaCore_Skeleton.Enums;
using LambdaCore_Skeleton.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace LambdaCore_Skeleton.Commands
{
    public class AttachFragmentCommand : ICommand
    {
        private const string SuccessfullMessage = "Successfully attached Fragment {0} to Core {1}!";
        private const string FailureMessage = "Failed to attach Fragment {0}!";
        private const string FragmentSuffix = "Fragment";

        private readonly string fragmentTypeName;
        private readonly string fragmentName;
        private readonly int pressureAffection;

        public AttachFragmentCommand(string fragmentTypeName, string fragmentName, int pressureAffection)
        {
            this.fragmentTypeName = fragmentTypeName;
            this.fragmentName = fragmentName;
            this.pressureAffection = pressureAffection;
        }

        public string Execute(ICoreManager coreManager)
        {
            var ifParsed = Enum.TryParse(this.fragmentTypeName, out FragmentType fragmentType);
            if (!ifParsed || this.pressureAffection < 0)
            {
                return string.Format(FailureMessage, this.fragmentName);
            }

            var fragmentTypeInfo = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name.Equals(fragmentType.ToString() + FragmentSuffix));

            var fragment = (IFragment)Activator.CreateInstance(fragmentTypeInfo, new object[] { this.fragmentName, fragmentType, this.pressureAffection });

            var result = coreManager.AttachFragment(fragment);
            if (result == default(char))
            {
                return string.Format(FailureMessage, this.fragmentName);
            }

            return string.Format(SuccessfullMessage, this.fragmentName, result);
        }
    }
}