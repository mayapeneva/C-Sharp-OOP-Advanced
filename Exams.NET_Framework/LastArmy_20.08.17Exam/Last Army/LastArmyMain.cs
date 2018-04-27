public class LastArmyMain
{
    public static void Main()
    {
        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();
        var gameController = new GameController();
        var engine = new Engine(reader, writer, gameController);
        engine.Run();
    }
}