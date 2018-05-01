namespace RecyclingStation.WasteDisposal.Core.Commands
{
    using Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ProcessGarbageCommand : Command
    {
        public ProcessGarbageCommand(GarbageProcessor garbageProcessor, string[] args)
            : base(garbageProcessor, args)
        {
        }

        public override string Execute()
        {
            var name = base.Args[0];
            var weight = double.Parse(base.Args[1]);
            var volumePerKg = double.Parse(base.Args[2]);
            var wasteType = base.Args[3] + "Garbage";

            var assembly = Assembly.GetExecutingAssembly();
            var classType = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(wasteType));
            var garbage = (IWaste)Activator.CreateInstance(classType, new object[] { name, weight, volumePerKg });

            return base.GarbageProcessor.ProcessWaste(garbage);
        }
    }
}