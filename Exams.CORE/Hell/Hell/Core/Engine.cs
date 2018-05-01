using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly IInputReader reader;
    private readonly IOutputWriter writer;
    private readonly IInterpreter interpreter;

    public Engine(IInputReader reader, IOutputWriter writer, IInterpreter interpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.interpreter = interpreter;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            List<string> arguments = this.parseInput(inputLine);
            this.writer.WriteLine(this.ProcessInput(arguments));
            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> parseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ProcessInput(List<string> arguments)
    {
        var command = this.interpreter.InterpretCommand(arguments);
        return command.Execute();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}