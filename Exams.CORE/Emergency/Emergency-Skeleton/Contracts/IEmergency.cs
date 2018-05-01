public interface IEmergency
{
    string Description { get; }

    EmergencyLevel Level { get; }

    RegistrationTime Time { get; }
}