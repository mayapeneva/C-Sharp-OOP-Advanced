public class Easy : Mission
{
    private const string DefaultName = "Suppression of civil rebellion";
    private const double DefaultEnduranceRequired = 20;
    private const double DefaultWearLevelDecrement = 30;

    public Easy(double scoreToComplete)
        : base(DefaultName, DefaultEnduranceRequired, scoreToComplete, DefaultWearLevelDecrement)
    {
    }
}