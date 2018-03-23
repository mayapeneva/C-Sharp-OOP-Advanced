using MilitaryElite_EXER.Interfaces;

namespace MilitaryElite_EXER.Classes
{
    public class Private : Privates
    {
        public Private(int id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName, salary)
        {
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}";
        }
    }
}