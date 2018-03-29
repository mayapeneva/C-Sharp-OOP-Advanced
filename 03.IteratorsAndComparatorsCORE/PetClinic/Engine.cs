using System;
using System.Collections.Generic;

public class Engine
{
    private readonly Dictionary<string, Clinic> clinics;
    private readonly Dictionary<string, Pet> pets;

    public Engine()
    {
        this.clinics = new Dictionary<string, Clinic>();
        this.pets = new Dictionary<string, Pet>();
    }

    public void Run()
    {
        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var command = input[0];
            try
            {
                switch (command)
                {
                    case "Create":
                        if (input[1] == "Pet")
                        {
                            var name = input[2];
                            var age = int.Parse(input[3]);
                            var kind = input[4];
                            this.pets.Add(name, new Pet(name, age, kind));
                        }
                        else
                        {
                            var name = input[2];
                            var rooms = int.Parse(input[3]);
                            this.clinics.Add(name, new Clinic(name, rooms));
                        }
                        break;

                    case "Add":
                        var petName = input[1];
                        var clinicName = input[2];
                        Console.WriteLine(this.clinics[clinicName].AddPet(this.pets[petName]));
                        break;

                    case "Release":
                        clinicName = input[1];
                        Console.WriteLine(this.clinics[clinicName].ReleasePet());
                        break;

                    case "HasEmptyRooms":
                        clinicName = input[1];
                        Console.WriteLine(this.clinics[clinicName].HasEmptyRooms());
                        break;

                    case "Print":
                        clinicName = input[1];
                        if (input.Length == 2)
                        {
                            Console.WriteLine(this.clinics[clinicName].Print());
                        }
                        else
                        {
                            var room = int.Parse(input[2]);
                            Console.WriteLine(this.clinics[clinicName].Print(room - 1));
                        }
                        break;
                }
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}