using System;
using System.Text;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly GameController gameController;

    public Engine(IReader reader, IWriter writer, GameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        var result = new StringBuilder();

        string input;
        while (!(input = this.reader.ReadLine()).Equals("Enough! Pull back!"))
        {
            try
            {
                this.gameController.ProcessInput(input);
            }
            catch (ArgumentException arg)
            {
                this.writer.WriteLine(arg.Message);
            }
        }

        this.gameController.RequestResult();
    }
}