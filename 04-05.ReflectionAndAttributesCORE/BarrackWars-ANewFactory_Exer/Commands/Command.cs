using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Commands
{
    public abstract class Command : IExecutable
    {
        [Inject]
        private string[] data;

        protected Command(string[] data)
        {
            this.data = data;
        }

        public string[] Data
        {
            get => this.data;
            set => this.data = value;
        }

        public abstract string Execute();
    }
}