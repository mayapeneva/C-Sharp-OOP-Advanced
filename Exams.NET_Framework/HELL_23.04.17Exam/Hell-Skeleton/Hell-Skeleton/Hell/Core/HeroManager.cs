using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IManager
{
    private readonly Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IHero hero)
    {
        this.heroes.Add(hero.Name, hero);

        return string.Format(Constants.HeroCreateMessage, hero.GetType().Name, hero.Name);
    }

    public string AddItemToHero(IItem item, string heroName)
    {
        this.heroes[heroName].AddCommonItem(item);

        return string.Format(Constants.ItemCreateMessage, item.Name, heroName);
    }

    public string AddRecipeToHero(IRecipe recipe, string heroName)
    {
        this.heroes[heroName].AddRecipe(recipe);

        return string.Format(Constants.RecipeCreatedMessage, recipe.Name, heroName);
    }

    public string Inspect(string heroName)
    {
        var heroType = this.heroes[heroName].GetType();
        return this.heroes[heroName].Inspect(heroType);
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        var count = 1;
        foreach (var hero in this.heroes.OrderByDescending(h => h.Value.PrimaryStats).ThenByDescending(h => h.Value.SecondaryStats))
        {
            result.AppendLine($"{count++}. {hero.Value.GetType().Name}: {hero.Key}");
            result.AppendLine(hero.Value.ToString().Trim(new[] { '[', ']' }).Trim());
        }

        return result.ToString();
    }
}