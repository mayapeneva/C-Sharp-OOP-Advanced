public class Hard : Mission
{
    private const string DefaultName = "Disposal of terrorists";
    private const double DefaultEnduranceRequired = 80;
    private const double DefaultWearLevelDecrement = 70;

    public Hard(double scoreToComplete)
        : base(DefaultName, DefaultEnduranceRequired, scoreToComplete, DefaultWearLevelDecrement)
    {
    }
}