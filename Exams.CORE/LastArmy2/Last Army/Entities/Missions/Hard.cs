public class Hard : Mission
{
    private const string DefaultName = "Disposal of terrorists";
    private const int HardEnduranceRequired = 80;
    private const int DefaultWearLevel = 70;

    public Hard(double scoreToComplete)
        : base(DefaultName, HardEnduranceRequired, scoreToComplete, DefaultWearLevel)
    {
    }
}