public class LastArmyMain
{
    public static void Main()
    {
        IArmy army = new Army();
        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        IWareHouse warehouse = new WareHouse(ammunitionFactory);

        MissionController missionController = new MissionController(army, warehouse);

        IMissionFactory missionFactory = new MissionFactory();
        ISoldierFactory soldierFactory = new SoldierFactory();

        IWriter writer = new ConsoleWriter();
        var gameController = new GameController(missionController, writer, missionFactory, soldierFactory, army, warehouse);

        IReader reader = new ConsoleReader();
        var engine = new Engine(reader, writer, gameController);
        engine.Run();
    }
}