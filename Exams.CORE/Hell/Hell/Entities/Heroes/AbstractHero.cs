using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero, IComparable<AbstractHero>
{
    private const string InventoryName = "HeroInventory";
    private const string CommonItems = "commonItems";

    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    private readonly IInventory inventory;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
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
        set => this.strength = value;
    }

    public long Agility
    {
        get => this.agility + this.inventory.TotalAgilityBonus;
        set => this.agility = value;
    }

    public long Intelligence
    {
        get => this.intelligence + this.inventory.TotalIntelligenceBonus;
        set => this.intelligence = value;
    }

    public long HitPoints
    {
        get => this.hitPoints + this.inventory.TotalHitPointsBonus;
        set => this.hitPoints = value;
    }

    public long Damage
    {
        get => this.damage + this.inventory.TotalDamageBonus;
        set => this.damage = value;
    }

    public long PrimaryStats => this.Strength + this.Agility + this.Intelligence;

    public long SecondaryStats => this.HitPoints + this.Damage;

    //REFLECTION
    public ICollection<IItem> Items => this.GetItems();

    private ICollection<IItem> GetItems()
    {
        var classType = Type.GetType(InventoryName);
        var fieldInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name.Equals(CommonItems));
        var dict = (IDictionary<string, IItem>)fieldInfo.GetValue(this.inventory);
        return dict.Values;
    }

    public void AddCommonItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public string GenerateReport()
    {
        var result = new StringBuilder();
        result.AppendLine($"{this.GetType()}: {this.Name}");
        result.AppendLine($"###HitPoints: {this.HitPoints}");
        result.AppendLine($"###Damage: {this.Damage}");
        result.AppendLine($"###Strength: {this.Strength}");
        result.AppendLine($"###Agility: {this.Agility}");
        result.AppendLine($"###Intelligence: {this.Intelligence}");
        result.AppendLine(this.Items.Count > 0
            ? $"###Items: {string.Join(", ", this.Items.Select(i => i.Name))}"
            : string.Format(Constants.NoneItems));

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

        result.AppendLine($"Hero: {this.Name}, Class: {this.GetType()}");
        result.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        result.AppendLine($"Strength: {this.Strength}");
        result.AppendLine($"Agility: {this.Agility}");
        result.AppendLine($"Intelligence: {this.Intelligence}");
        if (this.Items.Count == 0)
        {
            result.AppendLine("Items: None");
        }
        else
        {
            result.AppendLine("Items:");
            foreach (var item in this.Items)
            {
                result.AppendLine(item.ToString());
            }
        }

        return result.ToString().Trim();
    }
}