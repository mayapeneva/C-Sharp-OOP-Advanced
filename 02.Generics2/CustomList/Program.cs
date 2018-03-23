using System;
using CustomList;

public class Program
{
    public static void Main()
    {
        var commandInterpreter = new CommandInterpreter();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            commandInterpreter.InterpretCommand(input);
        }
    }
}