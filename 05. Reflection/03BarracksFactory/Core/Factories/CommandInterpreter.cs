using _03BarracksFactory.Contracts;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandFullName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName);

            Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandFullName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });

            var commandInjectFields = command.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.GetCustomAttributes<InjectAttribute>() != null).ToArray();

            var interpreterFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var commandInjectField in commandInjectFields)
            {
                commandInjectField.SetValue(command, interpreterFields.First(f => f.FieldType == commandInjectField.FieldType).GetValue(this));
            }
            return command;
        }
    }
}