using System.Collections.Generic;

public class RecipeItem : AbstractItem, IRecipe
{
    public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus, List<string> requiredItems)
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus)
    {
        this.RequiredItems = new List<string>(requiredItems);
    }

    public List<string> RequiredItems { get; private set; }
}