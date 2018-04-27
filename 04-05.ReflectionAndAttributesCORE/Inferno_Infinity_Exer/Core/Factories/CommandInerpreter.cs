using System;
using System.Linq;

public class CommandInerpreter
{
    public void InterpretCommand(string[] tokens, Repository repository
        )
    {
        var commandName = tokens[0] + "Command";
        var args = tokens.Skip(1).ToArray();

        var commandType = Type.GetType(commandName);
        var command = (ICommand)Activator.CreateInstance(commandType);
        command.Execute(args, repository);
    }
}