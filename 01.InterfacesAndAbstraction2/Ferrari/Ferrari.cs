public class Ferrari : ICar
{
    private const string DefaultModel = "488-Spider";

    public Ferrari(string driver)
    {
        this.Driver = driver;
        this.Model = DefaultModel;
    }

    public string Model { get; }
    public string Driver { get; }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string PushTheGasPeda()
    {
        return "Zadu6avam sA!";
    }
}