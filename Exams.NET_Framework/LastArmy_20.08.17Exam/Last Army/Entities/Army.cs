using System.Collections.Generic;

public class Army : IArmy
{
    private IList<ISoldier> soldiers;

    public Army()
    {
        this.soldiers = new List<ISoldier>();
    }

    public IList<ISoldier> Soldiers
    {
        get { return this.soldiers; }
    }

    public void AddSoldier(ISoldier soldier, string typeName)
    {
        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
    }
}