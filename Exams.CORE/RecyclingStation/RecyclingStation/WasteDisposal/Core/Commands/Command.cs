namespace RecyclingStation.WasteDisposal.Core.Commands
{
    using Interfaces;

    public abstract class Command : ICommand
    {
        protected Command(GarbageProcessor garbageProcessor, string[] args)
        {
            this.GarbageProcessor = garbageProcessor;
            this.Args = args;
        }

        public GarbageProcessor GarbageProcessor { get; }

        public string[] Args { get; }

        public abstract string Execute();
    }
}