public abstract class AbstractItemCommand : AbstractCommand
{
    protected AbstractItemCommand(IManager heroManager, string name, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus)
        : base(heroManager, name)
    {
        this.HeroName = heroName;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitpointsBonus = hitpointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string HeroName { get; }
    public long StrengthBonus { get; }
    public long AgilityBonus { get; }
    public long IntelligenceBonus { get; }
    public long HitpointsBonus { get; }
    public long DamageBonus { get; }
}