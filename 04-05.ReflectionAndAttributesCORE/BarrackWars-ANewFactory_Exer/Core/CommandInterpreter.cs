using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string NameSpace = "_03BarracksFactory.Commands.";
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var className = NameSpace + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(commandName.ToLower()) + "Command";
            var classType = Type.GetType(className);
            if (classType == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            var command =
                (IExecutable)Activator.CreateInstance(classType,
                    new object[] { data });

            var fieldsToInject = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes.Any(a => a.AttributeType == typeof(InjectAttribute))).ToArray();

            var interpreterFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fieldsToInject)
            {
                field.SetValue(command, interpreterFields.First(f => f.FieldType == field.FieldType).GetValue(this));
            }

            return command;
        }
    }
}