public interface ICenterFactory
{
    IEmergencyCenter CreateCenter(string type, object[] args);
}