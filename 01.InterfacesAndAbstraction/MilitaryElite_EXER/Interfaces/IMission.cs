namespace MilitaryElite_EXER.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        string State { get; }

        void CompleteMission();
    }
}