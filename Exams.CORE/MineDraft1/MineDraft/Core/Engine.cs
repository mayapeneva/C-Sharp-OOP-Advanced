using System;
using System.Linq;

public class Engine
{
    private readonly ICommandInterpreter interpreter;

    public Engine(ICommandInterpreter interpreter)
    {
        this.interpreter = interpreter;
    }

    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine();
            var data = input.Split().ToList();
            if (data[0] != "Shutdown")
            {
                Console.WriteLine(this.interpreter.ProcessCommand(data));
            }
            else
            {
                Console.WriteLine(this.interpreter.ProcessCommand(data));
                Environment.Exit(0);
            }
        }
    }
}