public interface IEmergencyFactory
{
    IEmergency CreateEmergency(string type, object[] args);
}