using MilitaryElite_EXER.Interfaces;

namespace MilitaryElite_EXER.Classes
{
    public abstract class SpecialisedSoldiers : Privates, ISpecialisedSoldier
    {
        protected SpecialisedSoldiers(int id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps { get; }
    }
}