using System;
using System.Collections.Generic;

public class HarvesterController : IHarvesterController
{
    private const Mode InitialMode = Mode.Full;

    private readonly List<IHarvester> harvesters;
    private readonly IEnergyRepository energyRepository;
    private readonly IHarvesterFactory factory;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.Mode = InitialMode;
        this.harvesters = new List<IHarvester>();
        this.factory = new HarvesterFactory();
    }

    public double OreProduced { get; private set; }

    public Mode Mode { get; private set; }

    public IReadOnlyCollection<IHarvester> Entities => this.harvesters.AsReadOnly();

    public string Register(IList<string> arguments)
    {
        var harvester = this.factory.GenerateHarvester(arguments);
        this.harvesters.Add(harvester);
        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }

    public string Produce()
    {
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.Mode == Mode.Full)
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.Mode == Mode.Half)
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.Mode == Mode.Energy)
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }

            if (this.Mode == Mode.Energy)
            {
                minedOres = minedOres * 20 / 100;
            }
            else if (this.Mode == Mode.Half)
            {
                minedOres = minedOres * 50 / 100;
            }
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public string ChangeMode(string mode)
    {
        this.Mode = (Mode)Enum.Parse(typeof(Mode), mode);

        var reminder = new List<IHarvester>();
        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged,
            this.Mode);
    }
}