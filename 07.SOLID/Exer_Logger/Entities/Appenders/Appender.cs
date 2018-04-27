using Logger.Entities.Enums;
using Logger.Interfaces;

namespace Logger.Entities.Appenders
{
    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
            this.File = new LogFile();
        }

        public LogFile File { get; set; }

        public ILayout Layout => this.layout;

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, string reportLevel, string message);
    }
}