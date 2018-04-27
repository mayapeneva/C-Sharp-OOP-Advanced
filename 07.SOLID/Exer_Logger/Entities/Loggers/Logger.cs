using Logger.Entities.Enums;
using Logger.Interfaces;
using System;
using System.Collections.Generic;

namespace Logger.Entities.Loggers
{
    public class Loger : ILogger
    {
        private readonly List<IAppender> appenders;

        public Loger(List<IAppender> appenders)
        {
            this.appenders = new List<IAppender>(appenders);
        }

        public void Error(string dataTime, string message)
        {
            this.Log(dataTime, "Error", message);
        }

        public void Info(string dataTime, string message)
        {
            this.Log(dataTime, "Info", message);
        }

        public void Fatal(string dataTime, string message)
        {
            this.Log(dataTime, "Fatal", message);
        }

        public void Critical(string dataTime, string message)
        {
            this.Log(dataTime, "Critical", message);
        }

        public void Warning(string dataTime, string message)
        {
            this.Log(dataTime, "Warning", message);
        }

        private void Log(string dataTime, string reportLevel, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                var currentReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);
                if (appender.ReportLevel <= currentReportLevel)
                {
                    appender.Append(dataTime, reportLevel, message);
                }
            }
        }
    }
}