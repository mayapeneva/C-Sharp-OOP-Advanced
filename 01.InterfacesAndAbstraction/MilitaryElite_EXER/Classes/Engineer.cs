using MilitaryElite_EXER.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite_EXER.Classes
{
    public class Engineer : SpecialisedSoldiers, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            result.AppendLine($"Corps: {this.Corps}");
            result.AppendLine("Repairs:");
            this.Repairs.ForEach(r => result.AppendLine(r.ToString()));

            return result.ToString().Trim();
        }
    }
}