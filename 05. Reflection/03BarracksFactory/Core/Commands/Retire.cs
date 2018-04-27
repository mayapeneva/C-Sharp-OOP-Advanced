using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Retire : Command
    {
        [Inject]
        private IRepository repository;

        public Retire(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitToRetire = this.Data[1];
            this.repository.RemoveUnit(unitToRetire);
            return unitToRetire + " retired!";
        }
    }
}