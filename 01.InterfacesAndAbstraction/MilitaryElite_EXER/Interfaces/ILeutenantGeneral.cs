using System.Collections.Generic;

namespace MilitaryElite_EXER.Interfaces
{
    public interface ILeutenantGeneral : IPrivate
    {
        List<ISoldier> Privates { get; }
    }
}