using MilitaryElite_EXER.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite_EXER.Classes
{
    public class Commando : SpecialisedSoldiers, ICommando
    {
        public Commando(int id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            result.AppendLine($"Corps: {this.Corps}");
            result.AppendLine("Missions:");
            this.Missions.ForEach(m => result.AppendLine(m.ToString()));

            return result.ToString().Trim();
        }
    }
}