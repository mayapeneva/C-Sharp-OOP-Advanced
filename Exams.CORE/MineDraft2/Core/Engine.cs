using System;
using System.Linq;

public class Engine
{
    private const string Shutdown = "Shutdown";

    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter interpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter interpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.interpreter = interpreter;
    }

    public void Run()
    {
        while (true)
        {
            var input = this.reader.ReadLine();
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            this.writer.WriteLine(this.interpreter.ProcessCommand(args));

            if (args[0].Equals(Shutdown))
            {
                Environment.Exit(0);
            }
        }
    }
}