public class Medium : Mission
{
    private const string DefaultName = "Capturing dangerous criminals";
    private const int MediumEnduranceRequired = 50;
    private const int DefaultWearLevel = 50;

    public Medium(double scoreToComplete)
        : base(DefaultName, MediumEnduranceRequired, scoreToComplete, DefaultWearLevel)
    {
    }
}