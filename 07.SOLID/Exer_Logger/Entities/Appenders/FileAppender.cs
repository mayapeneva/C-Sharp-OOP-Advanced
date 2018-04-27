using Logger.Interfaces;

namespace Logger.Entities.Appenders
{
    public class FileAppender : Appender

    {
        public FileAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string dateTime, string reportLevel, string message)
        {
            this.File.Write(this.Layout.DisplayLogs(dateTime, reportLevel, message));
        }
    }
}