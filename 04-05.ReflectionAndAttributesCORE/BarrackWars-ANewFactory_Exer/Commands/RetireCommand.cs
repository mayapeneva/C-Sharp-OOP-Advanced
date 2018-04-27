using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public RetireCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[1];
            this.repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
    }
}