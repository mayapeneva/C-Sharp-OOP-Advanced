using System;
using System.Collections.Generic;

public interface IEmergencyCenter
{
    string Name { get; }

    int AmountOfMaximumEmergencies { get; }

    List<IEmergency> Emergencies { get; }

    Boolean isForRetirement { get; }
}