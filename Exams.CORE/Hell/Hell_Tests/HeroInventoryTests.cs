using NUnit.Framework;
using System.Collections.Generic;

public class HeroInventoryTests
{
    [Test]
    public void AddItem_ShouldChangeStrengthBonus()
    {
        var inventory = new HeroInventory();
        var item1 = new CommonItem("Staff", 20, 10, 50, 100, 2000);
        var expected = 20;

        inventory.AddCommonItem(item1);

        Assert.AreEqual(expected, inventory.TotalStrengthBonus);
    }

    [Test]
    public void AddRecipe_ShouldNotChangeAgilityBonus()
    {
        var inventory = new HeroInventory();
        var recipe = new RecipeItem("Oculus", 10, 20, 30, 100, 250, new List<string> { "Staff", "Orb" });
        var expected = 0;

        inventory.AddRecipeItem(recipe);

        Assert.AreEqual(expected, inventory.TotalAgilityBonus);
    }

    [Test]
    public void AddItemAddRecipeAddItemCombineRecipe_ShouldCombineRecipe()
    {
        var inventory = new HeroInventory();
        var item1 = new CommonItem("Staff", 20, 10, 50, 100, 200);
        var item2 = new CommonItem("Orb", 30, 40, 200, 150, 350);
        var recipe = new RecipeItem("Oculus", 200, 300, 100, 1000, 2500, new List<string> { "Staff", "Orb" });
        var expected = 100;

        inventory.AddCommonItem(item1);
        inventory.AddRecipeItem(recipe);
        inventory.AddCommonItem(item2);

        Assert.AreEqual(expected, inventory.TotalIntelligenceBonus);
    }

    [Test]
    public void AddTwoItemsAddRecipeCombineRecipe_ShouldCombineRecipe()
    {
        var inventory = new HeroInventory();
        var item1 = new CommonItem("Staff", 20, 10, 50, 100, 200);
        var item2 = new CommonItem("Orb", 30, 40, 250, 150, 350);
        var recipe = new RecipeItem("Oculus", 400, 300, 100, 1000, 2500, new List<string> { "Staff", "Orb" });
        var expected = 2500;

        inventory.AddCommonItem(item1);
        inventory.AddCommonItem(item2);
        inventory.AddRecipeItem(recipe);

        Assert.AreEqual(expected, inventory.TotalDamageBonus);
    }

    [Test]
    public void AddItemAddRecipeWithTwoRequiredItems_ShouldNotCombineRecipe()
    {
        var inventory = new HeroInventory();
        var item1 = new CommonItem("Staff", 20, 10, 50, 200, 300);
        var recipe = new RecipeItem("Oculus", 400, 500, 600, 1000, 2500, new List<string> { "Staff", "Orb" });
        var expected = 200;

        inventory.AddCommonItem(item1);
        inventory.AddRecipeItem(recipe);

        Assert.AreEqual(expected, inventory.TotalHitPointsBonus);
    }
}