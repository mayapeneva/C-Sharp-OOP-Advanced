using System;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        var classType = Type.GetType(soldierTypeName);
        return (ISoldier)Activator.CreateInstance(classType, name, age, experience, endurance);
    }
}