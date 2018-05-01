public class LastArmyMain
{
    public static void Main()
    {
        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();
        MissionController controller = new MissionController(army, wareHouse);

        IGameController interpreter = new GameController(controller, army, wareHouse);
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        var engine = new Engine(interpreter, reader, writer);
        engine.Run();
    }
}