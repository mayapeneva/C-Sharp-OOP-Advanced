using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Linq;

namespace RecyclingStation.Core
{
    public class ProcessStarter
    {
        private const string terminatingInput = "TimeToRecycle";
        private readonly IRecyclingStationManager recyclingStationManager;

        public ProcessStarter(IRecyclingStationManager recyclingStationManager)
        {
            this.recyclingStationManager = recyclingStationManager;
        }

        public IRecyclingStationManager RecyclingStationManager => this.recyclingStationManager;

        public void Start()
        {
            string input;
            while ((input = Console.ReadLine()) != terminatingInput)
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var methodName = tokens[0];
                var nonParsedParameters = default(string[]);
                if (tokens.Length == 2)
                {
                    nonParsedParameters = tokens[1].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                }

                var methodInfo = this.recyclingStationManager.GetType().GetMethods()
                    .FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                if (methodInfo != null)
                {
                    var methodParams = methodInfo.GetParameters();

                    object[] parsedParams = new object[methodParams.Length];
                    for (int i = 0; i < methodParams.Length; i++)
                    {
                        parsedParams[i] = Convert.ChangeType(nonParsedParameters[i], methodParams[i].ParameterType);
                    }

                    object result = methodInfo.Invoke(this.recyclingStationManager, parsedParams);
                    Console.WriteLine(result.ToString());
                }
            }
        }
    }
}