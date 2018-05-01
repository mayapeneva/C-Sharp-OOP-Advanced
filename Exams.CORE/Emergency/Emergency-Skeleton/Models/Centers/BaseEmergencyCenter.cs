using System;
using System.Collections.Generic;

public abstract class BaseEmergencyCenter : IEmergencyCenter
{
    protected BaseEmergencyCenter(string name, int amountOfMaximumEmergencies)
    {
        this.Name = name;
        this.AmountOfMaximumEmergencies = amountOfMaximumEmergencies;
        this.Emergencies = new List<IEmergency>();
    }

    public string Name { get; }

    public int AmountOfMaximumEmergencies { get; }

    public List<IEmergency> Emergencies { get; private set; }

    public Boolean isForRetirement => this.Emergencies.Count == this.AmountOfMaximumEmergencies;
}