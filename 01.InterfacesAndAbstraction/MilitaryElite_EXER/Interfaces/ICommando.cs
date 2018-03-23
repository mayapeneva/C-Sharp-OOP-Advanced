using MilitaryElite_EXER.Classes;
using System.Collections.Generic;

namespace MilitaryElite_EXER.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        List<Mission> Missions { get; }
    }
}