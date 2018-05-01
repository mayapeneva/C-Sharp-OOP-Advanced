namespace RecyclingStation.WasteDisposal.Core.Commands
{
    using IO;

    public class StatusCommand : Command
    {
        public StatusCommand(GarbageProcessor garbageProcessor, string[] args)
            : base(garbageProcessor, args)
        {
        }

        public override string Execute()
        {
            var data = base.GarbageProcessor.ProcessingData;
            return string.Format(OutpuMessages.GarbageStatus, data.EnergyBalance, data.CapitalBalance);
        }
    }
}