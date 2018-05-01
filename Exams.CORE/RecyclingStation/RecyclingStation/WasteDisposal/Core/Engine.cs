namespace RecyclingStation.WasteDisposal.Core
{
    using Interfaces;

    public class Engine
    {
        private readonly CommandInterpreter interpreter;
        private readonly GarbageProcessor garbageProcessor;

        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(CommandInterpreter interpreter, GarbageProcessor garbageProcessor, IReader reader, IWriter writer)
        {
            this.interpreter = interpreter;
            this.garbageProcessor = garbageProcessor;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input;
            while ((input = this.reader.ReadLine()) != "TimeToRecycle")
            {
                var tokens = input.Split();

                var command = this.interpreter.InterpretCommand(this.garbageProcessor, tokens);
                this.writer.WriteLine(command.Execute());
            }
        }
    }
}