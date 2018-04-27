public class Ruby : Gem
{
    private const string RubyGemKind = "Ruby";
    private const int RubyStrength = 7;
    private const int RubyAgility = 2;
    private const int RubyVitality = 5;

    public Ruby(GemClarity clarity)
        : base(RubyGemKind, RubyStrength, RubyAgility, RubyVitality, clarity)
    {
    }
}