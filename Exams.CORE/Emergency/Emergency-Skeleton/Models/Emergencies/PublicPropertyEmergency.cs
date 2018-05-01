public class PublicPropertyEmergency : BaseEmergency
{
    public PublicPropertyEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, int damage)
        : base(description, emergencyLevel, registrationTime)
    {
        this.Damage = damage;
    }

    public int Damage { get; }
}