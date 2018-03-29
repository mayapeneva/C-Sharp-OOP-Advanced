using System;

namespace PetClinic_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var commandManager = new CommandManager();
            for (int i = 0; i < n; i++)
            {
                commandManager.InterpredCommand(Console.ReadLine().Split());
            }
        }
    }
}