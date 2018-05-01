using System.Text;

public class CommonItem : IItem
{
    public CommonItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name { get; }
    public long StrengthBonus { get; }
    public long AgilityBonus { get; }
    public long IntelligenceBonus { get; }
    public long HitPointsBonus { get; }
    public long DamageBonus { get; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"###Item: {this.Name}");
        result.AppendLine($"###+{this.StrengthBonus} Strength");
        result.AppendLine($"###+{this.AgilityBonus} Agility");
        result.AppendLine($"###+{this.IntelligenceBonus} Intelligence");
        result.AppendLine($"###+{this.HitPointsBonus} HitPoints");
        result.AppendLine($"###+{this.DamageBonus} Damage");

        return result.ToString().Trim();
    }
}