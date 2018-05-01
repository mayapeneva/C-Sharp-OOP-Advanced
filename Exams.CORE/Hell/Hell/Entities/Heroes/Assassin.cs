public class Assassin : AbstractHero
{
    private const int DefaultStrength = 25;
    private const int DefaultAgility = 100;
    private const int DefaultIntelligence = 15;
    private const int DefaultHitPoints = 150;
    private const int DefaultDamage = 300;

    public Assassin(string name)
        : base(name, DefaultStrength, DefaultAgility, DefaultIntelligence, DefaultHitPoints, DefaultDamage)
    {
    }
}