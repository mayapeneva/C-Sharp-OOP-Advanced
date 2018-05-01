using System;
using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            var classType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(type));
            return (ISet)Activator.CreateInstance(classType, name);
        }
    }
}