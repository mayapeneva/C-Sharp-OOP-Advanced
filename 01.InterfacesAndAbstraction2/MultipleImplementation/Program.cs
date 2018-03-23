using System;

public class Program
{
    public static void Main()
    {
        var name = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());
        var id = Console.ReadLine();
        var birthdate = Console.ReadLine();

        IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        Console.WriteLine(identifiable.Id);

        IBirthable birthable = new Citizen(name, age, id, birthdate);
        Console.WriteLine(birthable.Birthdate);
    }
}