using LambdaCore_Skeleton.Enums;
using LambdaCore_Skeleton.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace LambdaCore_Skeleton.Commands
{
    public class CreateCoreCommand : ICommand
    {
        private const string SuccessfullMessage = "Successfully created Core {0}!";
        private const string FailureMessage = "Failed to create Core!";
        private const string CoreSuffix = "Core";

        private readonly string coreTypeName;
        private readonly int durability;

        public CreateCoreCommand(string coreTypeName, int durability)
        {
            this.coreTypeName = coreTypeName;
            this.durability = durability;
        }

        public string Execute(ICoreManager coreManager)
        {
            var ifParsed = Enum.TryParse(this.coreTypeName, out CoreType coreType);
            if (!ifParsed || this.durability < 0)
            {
                return FailureMessage;
            }

            var coreTypeInfo = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name.Equals(coreType.ToString() + CoreSuffix));

            var core = (ICore)Activator.CreateInstance(coreTypeInfo, new object[] { coreType, this.durability });

            var coreName = coreManager.AddCore(core);
            return string.Format(SuccessfullMessage, coreName);
        }
    }
}