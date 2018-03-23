using MilitaryElite_EXER.Classes;
using System.Collections.Generic;

namespace MilitaryElite_EXER.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        List<Repair> Repairs { get; }
    }
}