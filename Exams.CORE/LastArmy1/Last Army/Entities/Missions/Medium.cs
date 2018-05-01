public class Medium : Mission
{
    private const string DefaultName = "Capturing dangerous criminals";
    private const double DefaultEnduranceRequired = 50;
    private const double DefaultWearLevelDecrement = 50;

    public Medium(double scoreToComplete)
        : base(DefaultName, DefaultEnduranceRequired, scoreToComplete, DefaultWearLevelDecrement)
    {
    }
}