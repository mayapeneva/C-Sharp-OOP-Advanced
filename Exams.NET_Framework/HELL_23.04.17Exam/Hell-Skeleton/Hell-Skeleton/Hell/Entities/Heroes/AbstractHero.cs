using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero, IComparable<AbstractHero>
{
    private readonly IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage)
    {
        this.Name = name;
        this.Strength = strength;
        this.Agility = agility;
        this.Intelligence = intelligence;
        this.HitPoints = hitPoints;
        this.Damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; }

    public long Strength
    {
        get => this.strength + this.inventory.TotalStrengthBonus;
        private set => this.strength = value;
    }

    public long Agility
    {
        get => this.agility + this.inventory.TotalAgilityBonus;
        private set => this.agility = value;
    }

    public long Intelligence
    {
        get => this.intelligence + this.inventory.TotalIntelligenceBonus;
        private set => this.intelligence = value;
    }

    public long HitPoints
    {
        get => this.hitPoints + this.inventory.TotalHitPointsBonus;
        private set => this.hitPoints = value;
    }

    public long Damage
    {
        get => this.damage + this.inventory.TotalDamageBonus;
        private set => this.damage = value;
    }

    public long PrimaryStats => this.Strength + this.Agility + this.Intelligence;

    public long SecondaryStats => this.HitPoints + this.Damage;

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            var fieldInfo = this.inventory.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
            var commonItems = (Dictionary<string, IItem>)fieldInfo.GetValue(this.inventory);
            return commonItems.Values.ToList();
        }
        private set => this.Items = new List<IItem>();
    }

    public void AddCommonItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public string Inspect(Type heroType)
    {
        var result = new StringBuilder();
        result.AppendLine($"Hero: {this.Name}, Class: {heroType}");
        result.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        result.AppendLine($"Strength: {this.Strength}");
        result.AppendLine($"Agility: {this.Agility}");
        result.AppendLine($"Intelligence: {this.Intelligence}");

        if (this.Items.Count > 0)
        {
            result.AppendLine("Items:");
            foreach (var item in this.Items)
            {
                result.AppendLine($"###Item: {item.Name}");
                result.AppendLine(item.ToString());
            }
        }
        else
        {
            result.AppendLine("Items: None");
        }

        return result.ToString().Trim();
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"###HitPoints: {this.HitPoints}");
        result.AppendLine($"###Damage: {this.Damage}");
        result.AppendLine($"###Strength: {this.Strength}");
        result.AppendLine($"###Agility: {this.Agility}");
        result.AppendLine($"###Intelligence: {this.Intelligence}");
        result.AppendLine(this.Items.Count > 0
            ? $"###Items: {string.Join(", ", this.Items.Select(i => i.Name).OrderByDescending(n => n))}"
            : "###Items: None");

        return result.ToString();
    }
}