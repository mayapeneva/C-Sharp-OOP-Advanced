using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandName = "Command";

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController, IEnergyRepository energyRepository)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
        this.EnergyRepository = energyRepository;
    }

    public IHarvesterController HarvesterController { get; }
    public IProviderController ProviderController { get; }
    public IEnergyRepository EnergyRepository { get; }

    public string ProcessCommand(IList<string> args)
    {
        var commandName = args[0] + CommandName;

        var assembly = Assembly.GetExecutingAssembly();
        var classType = assembly.GetType(commandName);

        var command = (ICommand)Activator.CreateInstance(classType, args.Skip(1).ToList());

        var requiredProps = classType.GetProperties()
            .Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(RefreshEntitiesAttribute))).ToArray();

        var interpreterProps = this.GetType().GetProperties();
        foreach (var prop in requiredProps)
        {
            prop.SetValue(command, interpreterProps.First(p => p.PropertyType == prop.PropertyType).GetValue(this));
        }

        return command.Execute();
    }
}