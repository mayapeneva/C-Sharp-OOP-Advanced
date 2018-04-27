using System;

public class Program
{
    public static void Main()
    {
        string input;
        var commandManager = new CommandManager();
        while ((input = Console.ReadLine()) != "drop")
        {
            commandManager.InterpredCommand(input.Split());
        }
    }
}