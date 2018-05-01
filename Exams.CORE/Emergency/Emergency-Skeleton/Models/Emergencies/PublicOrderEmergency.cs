public class PublicOrderEmergency : BaseEmergency
{
    public PublicOrderEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, string status)
        : base(description, emergencyLevel, registrationTime)
    {
        this.Status = status;
    }

    public string Status { get; set; }
}