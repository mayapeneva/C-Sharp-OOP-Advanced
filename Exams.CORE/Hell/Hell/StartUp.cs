public class StartUp
{
    public static void Main()
    {
        IManager manager = new HeroManager();
        IInterpreter interpreter = new CommandInterpreter(manager);

        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
        Engine engine = new Engine(reader, writer, interpreter);
        engine.Run();
    }
}