using System;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        var classType = Type.GetType(name);
        return (IAmmunition)Activator.CreateInstance(classType, name);
    }
}