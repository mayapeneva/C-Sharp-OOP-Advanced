using System.Text;

public class CommonItem : AbstractItem
{
    public CommonItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus)
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus)
    {
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"###+{this.StrengthBonus} Strength");
        result.AppendLine($"###+{this.AgilityBonus} Agility");
        result.AppendLine($"###+{this.IntelligenceBonus} Intelligence");
        result.AppendLine($"###+{this.HitPointsBonus} HitPoints");
        result.AppendLine($"###+{this.DamageBonus} Damage");

        return result.ToString().Trim();
    }
}