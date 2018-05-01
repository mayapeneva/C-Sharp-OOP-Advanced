using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private Mode mode;
    private readonly List<IHarvester> harvesters;
    private readonly IHarvesterFactory factory;

    public HarvesterController()
    {
        this.mode = Mode.Full;
        this.harvesters = new List<IHarvester>();
        this.factory = new HarvesterFactory();
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }

    public string ChangeMode(string mode)
    {
        var ifParsed = Enum.TryParse(mode, out Mode newMode);
        if (ifParsed)
        {
            this.mode = newMode;

            List<IHarvester> reminder = new List<IHarvester>();
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

            return string.Format(Constants.ModeChanged, mode);
        }

        return string.Empty;
    }

    public double CalculateNeededEnergy()
    {
        double neededEnergy = this.harvesters.Select(h => h.EnergyRequirement).Sum();
        if (this.mode.Equals(Mode.Half))
        {
            neededEnergy /= 2;
        }
        else if (this.mode.Equals(Mode.Energy))
        {
            neededEnergy *= 0.2;
        }

        return neededEnergy;
    }

    public string Produce()
    {
        var minedOres = this.harvesters.Sum(h => h.Produce());
        if (this.mode.Equals(Mode.Half))
        {
            minedOres /= 2;
        }
        else if (this.mode.Equals(Mode.Energy))
        {
            minedOres *= 0.2;
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreProducedToday, minedOres);
    }
}