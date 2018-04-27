public interface IGem
{
    string Kind { get; }
    int Strength { get; }
    int Agility { get; }
    int Vitality { get; }
    GemClarity Clarity { get; }
}