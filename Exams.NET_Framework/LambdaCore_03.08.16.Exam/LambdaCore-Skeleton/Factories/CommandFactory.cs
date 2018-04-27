using LambdaCore_Skeleton.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace LambdaCore_Skeleton.Factories
{
    public class CommandFactory
    {
        private const string CommandSuffix = "Command";

        public ICommand CreateCommand(string[] tokens)
        {
            var commandName = tokens[0].Trim(':') + CommandSuffix;
            var commandTypeInfo = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(c => c.Name.Equals(commandName));

            var nonParsedParameters = default(string[]);
            if (tokens.Length > 1)
            {
                nonParsedParameters = tokens.Skip(1).ToArray();
            }

            if (commandTypeInfo != null)
            {
                var commandConstrInfo = commandTypeInfo.GetConstructors().First();

                object[] parsedParams = ParseParams(commandConstrInfo, nonParsedParameters);

                return (ICommand)commandConstrInfo.Invoke(parsedParams);
            }

            return default(ICommand);
        }

        private static object[] ParseParams(ConstructorInfo commandConstrInfo, string[] nonParsedParameters)
        {
            var commandParams = commandConstrInfo.GetParameters().ToArray();

            var parsedParams = new object[commandParams.Length];
            for (int i = 0; i < commandParams.Length; i++)
            {
                parsedParams[i] = Convert.ChangeType(nonParsedParameters[i], commandParams[i].ParameterType);
            }

            return parsedParams;
        }
    }
}