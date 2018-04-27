public interface IAmmunition
{
    string Name { get; }

    double WearLevel { get; }

    void DecreaseWearLevel(double wearAmount);
}