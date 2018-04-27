using System.Collections.Generic;

public class Attack : ICommand
{
    public Dictionary<string, Blob> Execute(string[] command, Dictionary<string, Blob> blobs)
    {
        var attacker = blobs[command[1]];
        var target = blobs[command[2]];
        if (attacker.Health > 0 && target.Health > 0)
        {
            attacker.Attack.Execute(attacker, target);

            if (!target.Behavior.IsTriggered)
            {
                if (target.IfTriggerBehavior())
                {
                    target.Behavior.Trigger(target);
                }
            }
        }

        return blobs;
    }
}