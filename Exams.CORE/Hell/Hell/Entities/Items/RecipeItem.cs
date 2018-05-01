using System.Collections.Generic;

public class RecipeItem : IRecipe
{
    public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, IList<string> requiredItems)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
        this.RequiredItems = requiredItems;
    }

    public string Name { get; }
    public long StrengthBonus { get; }
    public long AgilityBonus { get; }
    public long IntelligenceBonus { get; }
    public long HitPointsBonus { get; }
    public long DamageBonus { get; }
    public IList<string> RequiredItems { get; }
}