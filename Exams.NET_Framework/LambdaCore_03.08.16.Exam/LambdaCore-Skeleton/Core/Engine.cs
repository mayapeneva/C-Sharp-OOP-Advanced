using LambdaCore_Skeleton.Factories;
using LambdaCore_Skeleton.Interfaces;
using System;
using System.Linq;

namespace LambdaCore_Skeleton.Core
{
    public class Engine
    {
        private const string QuitMessage = "System Shutdown!";

        private readonly CommandFactory commandFactory;
        private readonly ICoreManager coreManager;

        public Engine(CommandFactory commandFactory, ICoreManager coreManager)
        {
            this.commandFactory = commandFactory;
            this.coreManager = coreManager;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != QuitMessage)
            {
                var tokens = input.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var command = this.commandFactory.CreateCommand(tokens);

                Console.WriteLine(command.Execute(this.coreManager));
            }
        }
    }
}