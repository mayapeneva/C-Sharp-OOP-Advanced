namespace RecyclingStation
{
    using WasteDisposal.Core;
    using WasteDisposal.IO;
    using WasteDisposal.Models.ProcessingData;

    public class RecyclingStationMain
    {
        public static void Main()
        {
            var processingData = new ProcessingData();
            var strategyHolder = new StrategyHolder();
            var garbageProcessor = new GarbageProcessor(processingData, strategyHolder);

            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var interpreter = new CommandInterpreter();
            var engine = new Engine(interpreter, garbageProcessor, reader, writer);
            engine.Run();
        }
    }
}