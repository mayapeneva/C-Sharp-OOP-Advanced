using System.Collections.Generic;

public interface IHarvesterController : IController
{
    double OreProduced { get; }

    IReadOnlyCollection<IHarvester> Entities { get; }

    string ChangeMode(string mode);
}