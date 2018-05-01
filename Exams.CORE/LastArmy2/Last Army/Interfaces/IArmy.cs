using System.Collections.Generic;

public interface IArmy
{
    IReadOnlyList<ISoldier> Soldiers { get; }

    void AddSoldier(string type, string name, int age, double experience, double endurance);

    void RegenerateTeam(string soldierType);
}