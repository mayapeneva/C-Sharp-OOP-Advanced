public class Axe : Weapon
{
    private const int AxeMinDamage = 5;
    private const int AxeMaxDamage = 10;
    private const int AxeSockets = 4;

    public Axe(string name, Rarity rarity)
        : base(name, AxeMinDamage, AxeMaxDamage, AxeSockets, rarity)
    {
    }
}