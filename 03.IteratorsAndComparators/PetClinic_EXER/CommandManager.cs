using PetClinic_EXER.Models;
using System;
using System.Collections.Generic;

namespace PetClinic_EXER
{
    public class CommandManager
    {
        private readonly Dictionary<string, Pet> pets;
        private readonly Dictionary<string, Clinic> clinics;

        public CommandManager()
        {
            this.pets = new Dictionary<string, Pet>();
            this.clinics = new Dictionary<string, Clinic>();
        }

        public void InterpredCommand(string[] command)
        {
            try
            {
                this.ParseCommand(command);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ParseCommand(string[] command)
        {
            var firstCommand = command[0];
            var secondCommand = command[1];
            switch (firstCommand)
            {
                case "Create":
                    var name = command[2];
                    var number = int.Parse(command[3]);
                    if (secondCommand == "Pet")
                    {
                        this.pets[name] = new Pet(name, number, command[4]);
                    }
                    else
                    {
                        var clinic = new Clinic(name, number);
                        clinic.CreateClinic();
                        this.clinics[name] = clinic;
                    }
                    break;

                case "Add":
                    name = command[2];
                    Console.WriteLine(this.clinics[name].Add(this.pets[secondCommand]));
                    break;

                case "Release":
                    Console.WriteLine(this.clinics[secondCommand].Release());
                    break;

                case "HasEmptyRooms":
                    Console.WriteLine(this.clinics[secondCommand].HasEmptyRooms());
                    break;

                case "Print":
                    if (command.Length == 2)
                    {
                        this.clinics[secondCommand].Print();
                    }
                    else
                    {
                        this.clinics[secondCommand].PrintRoom(int.Parse(command[2]) - 1);
                    }
                    break;
            }
        }
    }
}