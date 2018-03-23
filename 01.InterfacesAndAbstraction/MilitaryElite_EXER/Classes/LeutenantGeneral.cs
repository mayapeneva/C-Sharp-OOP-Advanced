using MilitaryElite_EXER.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite_EXER.Classes
{
    public class LeutenantGeneral : Privates, ILeutenantGeneral
    {
        private List<ISoldier> privates;

        public LeutenantGeneral(int id, string firstName, string lastName, double salary, List<ISoldier> privates)
            : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public List<ISoldier> Privates
        {
            get { return this.privates; }
            private set { this.privates = new List<ISoldier>(); }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            result.AppendLine("Privates:");
            this.Privates.ForEach(p => result.AppendLine(p.ToString()));

            return result.ToString().Trim();
        }
    }
}