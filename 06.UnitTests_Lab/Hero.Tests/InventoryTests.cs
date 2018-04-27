using System;
using System.Collections.Generic;
using NUnit.Framework;

public class InventoryTests
{
    private HeroInventory inventory;
    private CommonItem item;
    private CommonItem item2;
    private RecipeItem recipe;

    [SetUp]
    public void InitialTest()
    {
        inventory = new HeroInventory();
        item = new CommonItem("Knife", 1, 1, 1, 1, 1);
        item2 = new CommonItem("Stick", 2, 2, 2, 2, 2);
        recipe = new RecipeItem("Spear", 10, 10, 10, 10, 10, new List<string> { "Knife", "Stick" });
        recipe = new RecipeItem("Oculus", 10, 10, 10, 10, 10, new List<string> { "Knife", "Stick" });
    }

    [Test]
    public void IfAddingRecipeWithTwoExistingCommonItemsChangesTheStrengthBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddCommonItem(this.item2);
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(10, this.inventory.TotalStrengthBonus, "Adding recipe with two exsiting commonItems is not affecting the TotalStrengthBonus");
    }

    [Test]
    public void IfAddingTwoCommonItemsAlreadyDeletedByARecipeChangesTheStrengthBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddCommonItem(this.item2);
        this.inventory.AddRecipeItem(this.recipe);
        this.inventory.AddCommonItem(this.item);

        Assert.AreEqual(11, this.inventory.TotalStrengthBonus, "Adding recipe with two exsiting commonItems is not affecting the TotalStrengthBonus");
    }

    [Test]
    public void IfAddingRecipeWithTwoNotExistingCommonItemsIsNotChangingTheStrengthBonus()
    {
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(0, this.inventory.TotalStrengthBonus, "Adding recipe with two not exsiting commonItems is affecting the TotalStrengthBonus");
    }

    [Test]
    public void IfAddingCommonItemChangesTheStrengthBonus()
    {
        this.inventory.AddCommonItem(this.item);

        Assert.AreEqual(1, this.inventory.TotalStrengthBonus, "Adding commonItem is not affecting the TotalStrengthBonus");
    }

    [Test]
    public void IfAddingCommonItemChangesTheAgilityBonus()
    {
        this.inventory.AddCommonItem(this.item);

        Assert.AreEqual(1, this.inventory.TotalAgilityBonus, "Adding commonItem is not affecting the TotalAgilityBonus");
    }

    [Test]
    public void IfAddingCommonItemChangesTheIntelligenceBonus()
    {
        this.inventory.AddCommonItem(this.item);

        Assert.AreEqual(1, this.inventory.TotalIntelligenceBonus, "Adding commonItem is not affecting the TotalIntelligenceBonus");
    }

    [Test]
    public void IfAddingCommonItemChangesTheHitPointsBonus()
    {
        this.inventory.AddCommonItem(this.item);

        Assert.AreEqual(1, this.inventory.TotalHitPointsBonus, "Adding commonItem is not affecting the TotalHitPointsBonus");
    }

    [Test]
    public void IfAddingCommonItemChangesTheDamageBonus()
    {
        this.inventory.AddCommonItem(this.item);

        Assert.AreEqual(1, this.inventory.TotalDamageBonus, "Adding commonItem is not affecting the TotalDamageBonus");
    }

    [Test]
    public void IfAddingRecipeWithTwoExistingCommonItemsChangesTheAgilityBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddCommonItem(this.item2);
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(10, this.inventory.TotalAgilityBonus, "Adding recipe with two exsiting commonItems is not affecting the TotalAgilityBonus");
    }

    [Test]
    public void IfAddingRecipeWithTwoExistingCommonItemsChangesTheIntelligenceBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddCommonItem(this.item2);
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(10, this.inventory.TotalIntelligenceBonus, "Adding recipe with two exsiting commonItems is not affecting the TotalIntelligenceBonus");
    }

    [Test]
    public void IfAddingRecipeWithTwoExistingCommonItemsChangesTheHitPointsBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddCommonItem(this.item2);
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(10, this.inventory.TotalHitPointsBonus, "Adding recipe with two exsiting commonItems is not affecting the TotalHitPointsBonus");
    }

    [Test]
    public void IfAddingRecipeWithTwoExistingCommonItemsChangesTheDamageBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddCommonItem(this.item2);
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(10, this.inventory.TotalDamageBonus, "Adding recipe with two exsiting commonItems is not affecting the TotalDamageBonus");
    }

    [Test]
    public void IfAddingRecipeWithOneExistingCommonItemsChangesTheStrengthBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(1, this.inventory.TotalStrengthBonus, "Adding recipe with one existing commonItem is not affecting the TotalStrengthBonus");
    }

    [Test]
    public void IfAddingRecipeWithOneExistingCommonItemsChangesTheAgilityBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(1, this.inventory.TotalAgilityBonus, "Adding recipe with one existing commonItem is not affecting the TotalAgilityBonus");
    }

    [Test]
    public void IfAddingRecipeWithOneExistingCommonItemsChangesTheIntelligenceBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(1, this.inventory.TotalIntelligenceBonus, "Adding recipe with one existing commonItem is not affecting the TotalIntelligenceBonus");
    }

    [Test]
    public void IfAddingRecipeWithOneExistingCommonItemsChangesTheHitPointsBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(1, this.inventory.TotalHitPointsBonus, "Adding recipe with one existing commonItem is not affecting the TotalHitPointsBonus");
    }

    [Test]
    public void IfAddingRecipeWithOneExistingCommonItemsChangesTheDamageBonus()
    {
        this.inventory.AddCommonItem(this.item);
        this.inventory.AddRecipeItem(this.recipe);

        Assert.AreEqual(1, this.inventory.TotalDamageBonus, "Adding recipe with one existing commonItem is not affecting the TotalDamageBonus");
    }

    [Test]
    public void AddingTwoEqualCommonItems()
    {
        this.inventory.AddCommonItem(this.item);

        Assert.Throws<ArgumentException>(() => this.inventory.AddCommonItem(this.item), "An item with the same key has been already added.");
    }

    [Test]
    public void AddingTwoEqualRecipeItems()
    {
        this.inventory.AddRecipeItem(this.recipe);

        Assert.Throws<ArgumentException>(() => this.inventory.AddRecipeItem(this.recipe), "An item with the same key has been already added.");
    }
}