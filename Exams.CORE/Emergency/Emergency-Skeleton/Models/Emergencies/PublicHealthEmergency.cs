public class PublicHealthEmergency : BaseEmergency
{
    public PublicHealthEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, int casualties)
        : base(description, emergencyLevel, registrationTime)
    {
        this.Casualties = casualties;
    }

    public int Casualties { get; }
}