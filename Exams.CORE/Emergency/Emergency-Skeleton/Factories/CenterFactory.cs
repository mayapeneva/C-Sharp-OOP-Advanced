using System;

public class CenterFactory : ICenterFactory
{
    public IEmergencyCenter CreateCenter(string type, object[] args)
    {
        var classType = Type.GetType(type);
        return (IEmergencyCenter)Activator.CreateInstance(classType, args);
    }
}