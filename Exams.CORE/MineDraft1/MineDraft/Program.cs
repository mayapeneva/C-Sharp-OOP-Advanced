public class Program
{
    public static void Main(string[] args)
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        IHarvesterController harvesterController = new HarvesterController(energyRepository);
        IProviderController providerController = new ProviderController(energyRepository);
        ICommandInterpreter interpreter = new CommandInterpreter(harvesterController, providerController);
        Engine engine = new Engine(interpreter);
        engine.Run();
    }
}