public class Sword : Weapon
{
    private const int SwordMinDamage = 4;
    private const int SwordMaxDamage = 6;
    private const int SwordSockets = 3;

    public Sword(string name, Rarity rarity)
        : base(name, SwordMinDamage, SwordMaxDamage, SwordSockets, rarity)
    {
    }
}