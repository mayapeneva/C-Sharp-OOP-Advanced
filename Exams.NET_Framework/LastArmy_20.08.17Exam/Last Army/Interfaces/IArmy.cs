using System.Collections.Generic;

public interface IArmy
{
    IList<ISoldier> Soldiers { get; }

    void AddSoldier(ISoldier soldier, string typeName);

    void RegenerateTeam(string soldierType);
}