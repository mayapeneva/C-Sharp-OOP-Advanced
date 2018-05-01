using System.Collections.Generic;

public interface IInterpreter
{
    ICommand InterpretCommand(List<string> arguments);
}