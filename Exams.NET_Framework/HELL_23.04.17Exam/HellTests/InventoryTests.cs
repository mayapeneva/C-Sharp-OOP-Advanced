using NUnit.Framework;
using System.Collections.Generic;

public class InventoryTests
{
    private HeroInventory inventory;

    [SetUp]
    public void InitialTest()
    {
        this.inventory = new HeroInventory();
    }

    [Test]
    public void AddingCommonItemsChangesStrengthBonus()
    {
        var item = new CommonItem("A", 1, 2, 3, 4, 5);

        this.inventory.AddCommonItem(item);

        Assert.AreEqual(1, this.inventory.TotalStrengthBonus);
    }

    [Test]
    public void AddingCommonItemsChangesAgilityBonus()
    {
        var item = new CommonItem("A", 1, 2, 3, 4, 5);

        this.inventory.AddCommonItem(item);

        Assert.AreEqual(2, this.inventory.TotalAgilityBonus);
    }

    [Test]
    public void AddingCommonItemsChangesIntelligenceBonus()
    {
        var item = new CommonItem("A", 1, 2, 3, 4, 5);

        this.inventory.AddCommonItem(item);

        Assert.AreEqual(3, this.inventory.TotalIntelligenceBonus);
    }

    [Test]
    public void AddingCommonItemsChangesHitPointsBonus()
    {
        var item = new CommonItem("A", 1, 2, 3, 4, 5);

        this.inventory.AddCommonItem(item);

        Assert.AreEqual(4, this.inventory.TotalHitPointsBonus);
    }

    [Test]
    public void AddingCommonItemsChangesDamageBonus()
    {
        var item = new CommonItem("A", 1, 2, 3, 4, 5);

        this.inventory.AddCommonItem(item);

        Assert.AreEqual(5, this.inventory.TotalDamageBonus);
    }

    [Test]
    public void AddingRecipeItemDoesntChangeAgilityBonuss()
    {
        var recipe = new RecipeItem("U", 10, 20, 30, 40, 50, new List<string> { "A", "B" });

        this.inventory.AddRecipeItem(recipe);

        Assert.AreEqual(0, this.inventory.TotalAgilityBonus);
    }

    [Test]
    public void IfAddingRecipeWithTwoExistingCommonItemsChangesTheAgilityhBonus()
    {
        var item = new CommonItem("A", 1, 2, 3, 4, 5);
        var item2 = new CommonItem("B", 1, 2, 3, 4, 5);
        var recipe = new RecipeItem("U", 10, 20, 30, 40, 50, new List<string> { "A", "B" });

        this.inventory.AddCommonItem(item);
        this.inventory.AddCommonItem(item2);
        this.inventory.AddRecipeItem(recipe);

        Assert.AreEqual(20, this.inventory.TotalAgilityBonus);
    }
}