using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(string id, string firstName, string lastName, double salary, string corps, List<Mission> missions)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = new List<Mission>(missions);
    }

    public List<Mission> Missions { get; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine(base.ToString());
        result.AppendLine("Missions:");
        foreach (var mission in this.Missions)
        {
            result.AppendLine(mission.ToString());
        }

        return result.ToString().Trim();
    }
}