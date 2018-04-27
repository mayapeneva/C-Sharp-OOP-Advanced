using Logger.Interfaces;
using System;

namespace Logger.Entities.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string dateTime, string reportLevel, string message)
        {
            Console.WriteLine(this.Layout.DisplayLogs(dateTime, reportLevel, message));
            this.File.Write(this.Layout.DisplayLogs(dateTime, reportLevel, message));
        }
    }
}