using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(List<String> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type classType = Type.GetType(heroType);
            IHero hero = (IHero)Activator.CreateInstance(classType, new object[] { heroName });

            this.heroes[heroName] = hero;

            result = string.Format(Constants.HeroCreated, heroType, heroName);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(List<String> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        IItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);
        this.heroes[heroName].AddCommonItem(newItem);

        result = string.Format(Constants.ItemCreated, newItem.Name, heroName);
        return result;
    }

    public string AddRecipeToHero(List<String> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);
        List<string> requiredItems = arguments.Skip(7).ToList();

        IRecipe newRecipe = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus, requiredItems);
        this.heroes[heroName].AddRecipe(newRecipe);

        result = string.Format(Constants.RecipeCreatedd, newRecipe.Name, heroName);
        return result;
    }

    public string Inspect(List<String> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string GenerateReport()
    {
        var result = new StringBuilder();
        var counter = 1;
        foreach (var hero in this.heroes.Values.OrderByDescending(h => h.PrimaryStats).ThenByDescending(h => h.SecondaryStats))
        {
            result.Append($"{counter++}. ");
            result.AppendLine(hero.GenerateReport());
        }

        return result.ToString().Trim();
    }
}