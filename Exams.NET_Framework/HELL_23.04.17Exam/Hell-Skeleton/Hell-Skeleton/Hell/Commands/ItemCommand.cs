public class ItemCommand : AbstractItemCommand
{
    public ItemCommand(IManager heroManager, string name, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus)
        : base(heroManager, name, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus)
    {
    }

    public override string Execute()
    {
        var item = new CommonItem(this.Name, this.StrengthBonus, this.AgilityBonus, this.IntelligenceBonus, this.HitpointsBonus, this.DamageBonus);

        return this.HeroManager.AddItemToHero(item, this.HeroName);
    }
}