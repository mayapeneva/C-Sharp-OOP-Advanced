using LambdaCore_Skeleton.Core;
using LambdaCore_Skeleton.Factories;

namespace LambdaCore_Skeleton
{
    public class StartUp
    {
        public static void Main()
        {
            var commandFactory = new CommandFactory();
            var coreManager = new CoreManager();
            var engine = new Engine(commandFactory, coreManager);
            engine.Run();
        }
    }
}