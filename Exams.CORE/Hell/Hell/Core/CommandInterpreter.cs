using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : IInterpreter
{
    private const string CommandSufix = "Command";

    private readonly IManager manager;

    public CommandInterpreter(IManager manager)
    {
        this.manager = manager;
    }

    public ICommand InterpretCommand(List<string> arguments)
    {
        string commandName = arguments[0];
        arguments.RemoveAt(0);

        var classType = Assembly.GetCallingAssembly().GetTypes().First(t => t.Name.Equals(commandName + CommandSufix));
        return (ICommand)Activator.CreateInstance(classType, new object[] { arguments, this.manager });
    }
}