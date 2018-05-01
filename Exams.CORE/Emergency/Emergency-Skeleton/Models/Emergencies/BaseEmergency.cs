public abstract class BaseEmergency : IEmergency
{
    protected BaseEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime)
    {
        this.Description = description;
        this.Level = emergencyLevel;
        this.Time = registrationTime;
    }

    public string Description { get; }

    public EmergencyLevel Level { get; }

    public RegistrationTime Time { get; }
}