using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Add : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public Add(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            return unitType + " added!";
        }
    }
}