namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            var classType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(type));
            return (IInstrument)Activator.CreateInstance(classType);
        }
    }
}