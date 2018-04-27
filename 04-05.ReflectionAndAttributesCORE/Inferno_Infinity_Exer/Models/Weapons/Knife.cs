public class Knife : Weapon
{
    private const int KnifeMinDamage = 3;
    private const int KnifeMaxDamage = 4;
    private const int KnifeSockets = 2;

    public Knife(string name, Rarity rarity)
        : base(name, KnifeMinDamage, KnifeMaxDamage, KnifeSockets, rarity)
    {
    }
}