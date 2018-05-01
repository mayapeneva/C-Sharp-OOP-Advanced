using System.Collections.Generic;
using System.Linq;

public class Army : IArmy

{
    private readonly List<ISoldier> soldiers;
    private readonly SoldiersFactory factory;

    public Army()
    {
        this.soldiers = new List<ISoldier>();
        this.factory = new SoldiersFactory();
    }

    public IReadOnlyList<ISoldier> Soldiers => this.soldiers.AsReadOnly();

    public void AddSoldier(string type, string name, int age, double experience, double endurance)
    {
        var soldier = this.factory.CreateSoldier(type, name, age, experience, endurance);
        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        foreach (var soldier in this.soldiers.Where(s => s.GetType().Name.Equals(soldierType)))
        {
            soldier.Regenerate();
        }
    }
}