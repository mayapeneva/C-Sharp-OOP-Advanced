using System;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        var classType = Type.GetType(difficultyLevel);
        return (IMission)Activator.CreateInstance(classType, neededPoints);
    }
}