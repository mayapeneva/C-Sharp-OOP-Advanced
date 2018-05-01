using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        var classType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(name));
        return (IAmmunition)Activator.CreateInstance(classType, new object[] { name });
    }
}