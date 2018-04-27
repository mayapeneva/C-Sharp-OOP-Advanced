using System;

public class Engine
{
    private const string QuitCommand = "Enough! Pull back!";

    private IReader reader;
    private IWriter writer;
    private GameController gameController;

    public Engine(IReader reader, IWriter writer, GameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        string input;
        string result = string.Empty;

        while ((input = this.reader.ReadLine()) != QuitCommand)
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                result = arg.Message;
            }
        }

        //result = gameController.RequestResult();
        this.writer.WriteLine(result);
    }
}