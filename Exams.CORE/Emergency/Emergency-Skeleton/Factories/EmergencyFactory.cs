using System;

public class EmergencyFactory : IEmergencyFactory
{
    public IEmergency CreateEmergency(string type, object[] args)
    {
        var classType = Type.GetType(type);
        return (IEmergency)Activator.CreateInstance(classType, args);
    }
}