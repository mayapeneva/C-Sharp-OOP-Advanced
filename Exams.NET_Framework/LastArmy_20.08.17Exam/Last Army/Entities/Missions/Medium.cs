public class Medium : Mission
{
    private const double enduranceRequired = 50;

    public Medium(string name, double scoreToComplete) : base(name, enduranceRequired, scoreToComplete)
    {
    }
}