namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private const string EndCommand = "END";
        private const string LetsRockCommand = "LetsRock";

        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IFestivalController festivalCоntroller;
        private readonly ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController cоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = cоntroller;
        }

        public void Run()
        {
            string input;
            while ((input = this.reader.ReadLine()) != EndCommand)
            {
                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var arguments = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var commandName = arguments[0];

            if (commandName == LetsRockCommand)
            {
                return this.setCоntroller.PerformSets();
            }

            var method = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == commandName);

            return method.Invoke(this.festivalCоntroller, new object[] { arguments.Skip(1).ToArray() }).ToString();
        }
    }
}