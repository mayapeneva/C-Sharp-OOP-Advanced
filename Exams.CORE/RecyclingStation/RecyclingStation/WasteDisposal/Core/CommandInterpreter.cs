namespace RecyclingStation.WasteDisposal.Core
{
    using Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter
    {
        public ICommand InterpretCommand(GarbageProcessor garbageProcessor, string[] tokens)
        {
            var commandName = tokens[0] + "Command";
            var assembly = Assembly.GetExecutingAssembly();
            var classType = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(commandName));

            if (tokens.Count() > 1)
            {
                var args = tokens[1]?.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                return (ICommand)Activator.CreateInstance(classType, garbageProcessor, args);
            }

            return (ICommand)Activator.CreateInstance(classType, garbageProcessor, null);
        }
    }
}