using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(string id, string firstName, string lastName, double salary, List<Private> privates)
        : base(id, firstName, lastName, salary)
    {
        this.Privates = new List<Private>(privates);
    }

    public List<Private> Privates { get; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine(base.ToString());
        result.AppendLine("Privates:");
        foreach (var privateSoldier in this.Privates)
        {
            result.AppendLine(privateSoldier.ToString());
        }

        return result.ToString().Trim();
    }
}