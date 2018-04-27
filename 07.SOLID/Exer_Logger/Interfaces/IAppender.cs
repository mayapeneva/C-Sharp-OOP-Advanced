using Logger.Entities;
using Logger.Entities.Enums;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        LogFile File { get; }
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, string reportLevel, string message);
    }
}