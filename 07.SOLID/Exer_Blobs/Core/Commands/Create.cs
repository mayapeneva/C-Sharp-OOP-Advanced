using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Create : ICommand
{
    public Dictionary<string, Blob> Execute(string[] command, Dictionary<string, Blob> blobs)
    {
        var name = command[1];
        var health = int.Parse(command[2]);
        var damage = int.Parse(command[3]);

        var behaviorType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(b => b.Name == command[4]);
        var behavior = (IBehavior)Activator.CreateInstance(behaviorType);

        var attackType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name == command[5]);
        var attack = (IAttack)Activator.CreateInstance(attackType);

        blobs.Add(name, new Blob(name, health, damage, behavior, attack));

        return blobs;
    }
}