using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }
    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        var className = args[0] + "Command";
        //var classType = Type.GetType(className);
        //var classConstrs = classType.GetConstructors();
        //var command = (ICommand)classConstrs.First().Invoke(new object[] {args.Skip(1).ToList(), this.HarvesterController, this.ProviderController});
        //
        //return command.Execute();

        Type classType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == className);
        var command = (ICommand)Activator.CreateInstance(classType, new object[] { args.Skip(1).ToList(), this.HarvesterController, this.ProviderController });
        return command.Execute();
    }
}