using System.Linq;

[Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public abstract class Weapon : IWeapon
{
    protected Weapon(string name, int minDamage, int maxDamage, int sockets, Rarity rarity)
    {
        this.Name = name;
        this.Rarity = rarity;
        this.MinDamage = minDamage * (int)this.Rarity;
        this.MaxDamage = maxDamage * (int)this.Rarity;
        this.Sockets = sockets;
        this.Gems = new IGem[sockets];
    }

    public string Name { get; }
    public int MinDamage { get; private set; }
    public int MaxDamage { get; private set; }
    public int Sockets { get; }
    public IGem[] Gems { get; }
    public Rarity Rarity { get; }

    public void AddGem(IGem gem, int socketIndex)
    {
        if (socketIndex >= 0 && socketIndex < this.Sockets)
        {
            this.Gems[socketIndex] = gem;
        }
    }

    public void RemoveGem(int socketIndex)
    {
        if (socketIndex >= 0 && socketIndex < this.Sockets)
        {
            this.Gems[socketIndex] = null;
        }
    }

    public override string ToString()
    {
        this.ApplyGemStatsToWeapon();

        var gems = this.Gems.Where(g => g != null);
        var strength = this.Gems.Sum(g => g.Strength);
        var agility = this.Gems.Sum(g => g.Agility);
        var vitality = this.Gems.Sum(g => g.Vitality);
        return
            $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
    }

    private void ApplyGemStatsToWeapon()
    {
        foreach (var gem in this.Gems.Where(g => g != null))
        {
            this.MinDamage += gem.Strength * 2;
            this.MaxDamage += gem.Strength * 3;

            this.MinDamage += gem.Agility;
            this.MaxDamage += gem.Agility * 4;
        }
    }
}