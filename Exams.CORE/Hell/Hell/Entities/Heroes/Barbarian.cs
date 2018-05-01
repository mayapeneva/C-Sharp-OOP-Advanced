public class Barbarian : AbstractHero
{
    private const int DefaultStrength = 90;
    private const int DefaultAgility = 25;
    private const int DefaultIntelligence = 10;
    private const int DefaultHitPoints = 350;
    private const int DefaultDamage = 150;

    public Barbarian(string name)
        : base(name, DefaultStrength, DefaultAgility, DefaultIntelligence, DefaultHitPoints, DefaultDamage)
    {
    }
}