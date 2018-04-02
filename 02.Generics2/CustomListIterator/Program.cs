using CustomList;
using System;

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