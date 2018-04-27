using System;
using System.Linq;

public class Engine
{
    private Repository repository;
    private readonly CommandInerpreter interpreter;

    public Engine(Repository repository, CommandInerpreter interpreter)
    {
        this.repository = repository;
        this.interpreter = interpreter;
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(';').ToArray();
            if (tokens[0] != "Print")
            {
                this.interpreter.InterpretCommand(tokens, this.repository);
            }
            else
            {
                var weapon = this.repository.GetWeapon(tokens[1]);
                Console.WriteLine(weapon);
            }
        }
    }
}