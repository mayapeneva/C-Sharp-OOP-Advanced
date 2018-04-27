using System;

public class Program
{
    public static void Main()
    {
        var spy = new Spy();
        Console.WriteLine(spy.CollectGettersAndSetters("Hacker"));
    }
}