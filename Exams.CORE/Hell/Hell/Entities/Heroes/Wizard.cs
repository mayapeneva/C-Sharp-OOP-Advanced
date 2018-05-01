public class Wizard : AbstractHero
{
    private const int DefaultStrength = 25;
    private const int DefaultAgility = 25;
    private const int DefaultIntelligence = 100;
    private const int DefaultHitPoints = 100;
    private const int DefaultDamage = 250;

    public Wizard(string name)
        : base(name, DefaultStrength, DefaultAgility, DefaultIntelligence, DefaultHitPoints, DefaultDamage)
    {
    }
}