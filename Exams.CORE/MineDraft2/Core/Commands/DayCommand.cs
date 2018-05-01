using System.Collections.Generic;
using System.Text;

public class DayCommand : Command
{
    public DayCommand(List<string> arguments)
        : base(arguments)
    {
    }

    [RefreshEntities]
    public IHarvesterController HarvesterController { get; private set; }

    [RefreshEntities]
    public IProviderController ProviderController { get; private set; }

    [RefreshEntities]
    public IEnergyRepository EnergyRepository { get; private set; }

    public override string Execute()
    {
        var result = new StringBuilder();

        result.AppendLine(this.ProviderController.Produce());

        var neededEnergy = this.HarvesterController.CalculateNeededEnergy();

        if (this.EnergyRepository.TakeEnergy(neededEnergy))
        {
            result.AppendLine(this.HarvesterController.Produce());
            return result.ToString().Trim();
        }

        var nullresult = new StringBuilder();
        nullresult.AppendLine(string.Format(Constants.EnergyProducedToday, 0));
        nullresult.AppendLine(string.Format(Constants.OreProducedToday, 0));

        return nullresult.ToString().Trim();
    }
}