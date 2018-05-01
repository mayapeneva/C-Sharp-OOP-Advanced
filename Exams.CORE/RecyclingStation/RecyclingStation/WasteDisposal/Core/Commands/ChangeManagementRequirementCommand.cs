namespace RecyclingStation.WasteDisposal.Core.Commands
{
    using Models;
    using RecyclingStation.WasteDisposal.IO;

    public class ChangeManagementRequirementCommand : Command
    {
        public ChangeManagementRequirementCommand(GarbageProcessor garbageProcessor, string[] args)
            : base(garbageProcessor, args)
        {
        }

        public override string Execute()
        {
            var energyBalance = double.Parse(base.Args[0]);
            var capitalBalance = double.Parse(base.Args[1]);
            var garbageType = base.Args[2];

            this.GarbageProcessor.ChangeMangementRequirement(new ManagementRequirment(energyBalance, capitalBalance, garbageType));

            return string.Format(OutpuMessages.ManagementRequirement);
        }
    }
}