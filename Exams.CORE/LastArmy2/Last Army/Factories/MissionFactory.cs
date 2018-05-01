using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string type, double scoreToComplete)
    {
        var classType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(type));
        return (IMission)Activator.CreateInstance(classType, new object[] { scoreToComplete });
    }
}