public class Easy : Mission
{
    private const string DefaultName = "Suppression of civil rebellion";
    private const int EasyEnduranceRequired = 20;
    private const int DefaultWearLevel = 30;

    public Easy(double scoreToComplete)
        : base(DefaultName, EasyEnduranceRequired, scoreToComplete, DefaultWearLevel)
    {
    }
}