public class Program
{
    public static void Main()
    {
        var register = new EmergencyRegister();
        var emergencyFactory = new EmergencyFactory();
        var centerFactory = new CenterFactory();
        var manager = new EmergencyManagementSystem(register, emergencyFactory, centerFactory);

        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();
        var engine = new Engine(reader, writer, manager);
        engine.Run();
    }
}