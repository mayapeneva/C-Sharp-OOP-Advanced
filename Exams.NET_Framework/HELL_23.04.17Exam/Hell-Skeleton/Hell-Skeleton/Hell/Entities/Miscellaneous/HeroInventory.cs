using System.Collections.Generic;
using System.Linq;

public class HeroInventory : IInventory
{
    [Item]
    private Dictionary<string, IItem> commonItems;

    private readonly Dictionary<string, IRecipe> recipeItems;

    public HeroInventory()
    {
        this.commonItems = new Dictionary<string, IItem>();
        this.recipeItems = new Dictionary<string, IRecipe>();
    }

    private Dictionary<string, IItem> CommonItems
    {
        get => this.commonItems;
        set => this.commonItems = value;
    }

    public long TotalStrengthBonus
    {
        get { return this.commonItems.Values.Sum(i => i.StrengthBonus); }
    }

    public long TotalAgilityBonus
    {
        get { return this.commonItems.Values.Sum(i => i.AgilityBonus); }
    }

    public long TotalIntelligenceBonus
    {
        get { return this.commonItems.Values.Sum(i => i.IntelligenceBonus); }
    }

    public long TotalHitPointsBonus
    {
        get { return this.commonItems.Values.Sum(i => i.HitPointsBonus); }
    }

    public long TotalDamageBonus
    {
        get { return this.commonItems.Values.Sum(i => i.DamageBonus); }
    }

    public void AddCommonItem(IItem item)
    {
        this.commonItems.Add(item.Name, item);
        this.CheckRecipes();
    }

    public void AddRecipeItem(IRecipe recipe)
    {
        this.recipeItems.Add(recipe.Name, recipe);
        this.CheckRecipes();
    }

    private void CheckRecipes()
    {
        foreach (IRecipe recipe in this.recipeItems.Values)
        {
            var requiredItems = new List<string>(recipe.RequiredItems);

            foreach (var commonItem in this.commonItems.Values)
            {
                if (requiredItems.Contains(commonItem.Name))
                {
                    requiredItems.Remove(commonItem.Name);
                }
            }

            if (requiredItems.Count == 0)
            {
                this.CombineRecipe(recipe);
            }
        }
    }

    private void CombineRecipe(IRecipe recipe)
    {
        foreach (var requiredItem in recipe.RequiredItems)
        {
            this.commonItems.Remove(requiredItem);
        }

        var commonItem = new CommonItem(recipe.Name, recipe.StrengthBonus, recipe.AgilityBonus, recipe.IntelligenceBonus, recipe.HitPointsBonus, recipe.DamageBonus);

        this.commonItems.Add(commonItem.Name, commonItem);
    }
}