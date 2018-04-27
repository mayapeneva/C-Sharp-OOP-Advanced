public class Amethyst : Gem
{
    private const string AmethystGemKind = "Amethyst";
    private const int AmethystStrength = 2;
    private const int AmethystAgility = 8;
    private const int AmethystVitality = 4;

    public Amethyst(GemClarity clarity)
        : base(AmethystGemKind, AmethystStrength, AmethystAgility, AmethystVitality, clarity)
    {
    }
}