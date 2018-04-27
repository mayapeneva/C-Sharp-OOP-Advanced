public class Emerald : Gem
{
    private const string EmeraldGemKind = "Emerald";
    private const int EmeraldStrength = 1;
    private const int EmeraldAgility = 4;
    private const int EmeraldVitality = 9;

    public Emerald(GemClarity clarity)
        : base(EmeraldGemKind, EmeraldStrength, EmeraldAgility, EmeraldVitality, clarity)
    {
    }
}