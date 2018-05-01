using System;
using System.Linq;
using System.Reflection;

public class SoldiersFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        var classType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(soldierTypeName));
        return (ISoldier)Activator.CreateInstance(classType, new object[] { name, age, experience, endurance });
    }
}