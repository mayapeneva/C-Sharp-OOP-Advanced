public abstract class Gem : IGem
{
    protected Gem(string kind, int strength, int agility, int vitality, GemClarity clarity)
    {
        this.Kind = kind;
        this.Clarity = clarity;
        this.Strength = strength + (int)this.Clarity;
        this.Agility = agility + (int)this.Clarity;
        this.Vitality = vitality + (int)this.Clarity;
    }

    public string Kind { get; }
    public int Strength { get; }
    public int Agility { get; }
    public int Vitality { get; }
    public GemClarity Clarity { get; }
}