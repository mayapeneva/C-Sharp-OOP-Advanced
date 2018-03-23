using MilitaryElite_EXER.Interfaces;
using System;

namespace MilitaryElite_EXER.Classes
{
    public class Spy : ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CodeNumber = codeNumber;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int CodeNumber { get; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}" + Environment.NewLine + $"Code Number: {this.CodeNumber}";
        }
    }
}