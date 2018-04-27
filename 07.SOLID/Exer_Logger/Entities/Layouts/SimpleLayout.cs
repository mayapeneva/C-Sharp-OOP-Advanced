using Logger.Interfaces;

namespace Logger.Entities.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string DisplayLogs(string dataTime, string reportLevel, string message)
        {
            return $"{dataTime} - {reportLevel.ToUpper()} - {message}";
        }
    }
}