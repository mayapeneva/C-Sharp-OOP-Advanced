namespace Logger.Interfaces
{
    public interface ILayout
    {
        string DisplayLogs(string dataTime, string reportLevel, string message);
    }
}