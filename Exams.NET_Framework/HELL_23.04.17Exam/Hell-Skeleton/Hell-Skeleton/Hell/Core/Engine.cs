using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine : IEngine
{
    private const string CommandSuffix = "Command";
    private readonly IInputReader reader;
    private readonly IOutputWriter writer;
    private readonly IManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, IManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        string inputLine;
        while ((inputLine = this.reader.ReadLine()) != "Quit")
        {
            List<string> arguments = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            this.writer.WriteLine(this.ProcessInput(arguments));
        }

        this.writer.WriteLine(this.heroManager.ToString().Trim());
    }

    private string ProcessInput(List<string> arguments)
    {
        var commandName = arguments[0];
        var commandTypeInfo = Assembly.GetExecutingAssembly().GetTypes()
            .FirstOrDefault(c => c.Name.Equals(commandName + CommandSuffix));

        var nonParsedParameters = default(string[]);
        if (arguments.Count > 1)
        {
            nonParsedParameters = arguments.Skip(1).ToArray();
        }

        if (commandTypeInfo != null)
        {
            var commandConstrInfo = commandTypeInfo.GetConstructors().First();

            object[] parsedParams = ParseParams(commandConstrInfo, nonParsedParameters);
            parsedParams[0] = this.heroManager;
            var command = (ICommand)commandConstrInfo.Invoke(parsedParams);

            object result = command.Execute();

            return result.ToString();
        }

        return null;
    }

    private static object[] ParseParams(ConstructorInfo commandConstrInfo, string[] nonParsedParameters)
    {
        var commandParams = commandConstrInfo.GetParameters().Skip(1).ToArray();

        object[] parsedParams;
        if (nonParsedParameters.Length > 7)
        {
            var additionalParams = nonParsedParameters.Skip(7).ToArray();
            nonParsedParameters = nonParsedParameters.Take(7).ToArray();
            parsedParams = new object[commandParams.Length + 1];
            parsedParams[parsedParams.Length - 1] = additionalParams;
            commandParams = commandParams.Take(commandParams.Length - 1).ToArray();
        }
        else
        {
            parsedParams = new object[commandParams.Length + 1];
        }

        for (int i = 0; i < commandParams.Length; i++)
        {
            parsedParams[i + 1] = Convert.ChangeType(nonParsedParameters[i], commandParams[i].ParameterType);
        }

        return parsedParams;
    }
}