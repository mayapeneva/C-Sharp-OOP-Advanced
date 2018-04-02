﻿using MilitaryElite_EXER.Interfaces;

namespace MilitaryElite_EXER.Classes
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; }

        public string State { get; }

        public void CompleteMission()
        {
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}