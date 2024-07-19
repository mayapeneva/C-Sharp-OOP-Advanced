using System;

public class CombatLogger : Logger
{
    public override void Handle(LogType type, string message)
    {
        switch (type)
        {
            case LogType.ATTACK:
                Console.WriteLine(type + ": " + message);
                break;

            case LogType.MAGIC:
                Console.WriteLine(type + ": " + message);
                break;

            case LogType.TARGET:
                Console.WriteLine(type + ": " + message);
                break;

            case LogType.ERROR:
                Console.WriteLine(type + ": " + message);
                break;

            case LogType.EVENT:
                Console.WriteLine(type + ": " + message);
                break;
        }

        this.PassToSuccessor(type, message);
    }
}