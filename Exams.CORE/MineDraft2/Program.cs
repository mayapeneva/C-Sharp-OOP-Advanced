public class Program
{
    public static void Main()
    {
        IHarvesterController harvesterController = new HarvesterController();

        IEnergyRepository energyRepository = new EnergyRepository();
        IProviderController providerController = new ProviderController(energyRepository);

        ICommandInterpreter interpreter = new CommandInterpreter(harvesterController, providerController, energyRepository);
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        Engine engine = new Engine(reader, writer, interpreter);
        engine.Run();
    }
}