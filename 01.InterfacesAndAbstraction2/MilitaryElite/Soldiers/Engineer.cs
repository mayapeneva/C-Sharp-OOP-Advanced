using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName, double salary, string corps, List<Repair> repairs)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = new List<Repair>(repairs);
    }

    public List<Repair> Repairs { get; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine(base.ToString());
        result.AppendLine("Repairs:");
        foreach (var repair in this.Repairs)
        {
            result.AppendLine(repair.ToString());
        }

        return result.ToString().Trim();
    }
}