﻿using System;

namespace Person_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
            var birthableInterface = typeof(Citizen).GetInterface("IBirthable");
            var properties = identifiableInterface.GetProperties();
            Console.WriteLine(properties.Length);
            Console.WriteLine(properties[0].PropertyType.Name);

            properties = birthableInterface.GetProperties();
            Console.WriteLine(properties.Length);
            Console.WriteLine(properties[0].PropertyType.Name);

            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var id = Console.ReadLine();
            var birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
        }
    }
}