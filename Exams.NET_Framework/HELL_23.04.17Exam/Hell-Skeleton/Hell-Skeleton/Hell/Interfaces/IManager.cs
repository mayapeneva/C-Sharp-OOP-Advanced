public interface IManager
{
    string AddHero(IHero hero);

    string AddItemToHero(IItem item, string heroName);

    string AddRecipeToHero(IRecipe recipe, string heroName);

    string Inspect(string heroName);
}