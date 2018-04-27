public interface IWeapon
{
    string Name { get; }
    int MinDamage { get; }
    int MaxDamage { get; }
    int Sockets { get; }
    IGem[] Gems { get; }
    Rarity Rarity { get; }

    void AddGem(IGem gem, int socketIndex);

    void RemoveGem(int socketIndex);
}