using MilitaryElite_EXER.Interfaces;

namespace MilitaryElite_EXER.Classes
{
    public abstract class Privates : IPrivate
    {
        protected Privates(int id, string firstName, string lastName, double salary)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public double Salary { get; }
    }
}