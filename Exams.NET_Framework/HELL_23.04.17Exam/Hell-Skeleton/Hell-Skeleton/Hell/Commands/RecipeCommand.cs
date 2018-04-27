using System.Collections.Generic;

public class RecipeCommand : AbstractItemCommand
{
    private readonly List<string> requiredList;

    public RecipeCommand(IManager heroManager, string name, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus, params string[] requiredList)
        : base(heroManager, name, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus)
    {
        this.requiredList = new List<string>(requiredList);
    }

    public override string Execute()
    {
        var recipe = new RecipeItem(this.Name, this.StrengthBonus, this.AgilityBonus, this.IntelligenceBonus, this.HitpointsBonus, this.DamageBonus, this.requiredList);

        return this.HeroManager.AddRecipeToHero(recipe, this.HeroName);
    }
}