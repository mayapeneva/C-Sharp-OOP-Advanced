using System.Collections.Generic;

public interface IProviderController : IController
{
    double TotalEnergyProduced { get; }
    IReadOnlyCollection<IProvider> Entities { get; }

    string Repair(double val);
}