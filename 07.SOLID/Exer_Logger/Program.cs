using Logger.Entities;
using Logger.Entities.Appenders;
using Logger.Entities.Enums;
using Logger.Entities.Layouts;
using Logger.Entities.Loggers;
using Logger.Factories;
using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Logger
{
    public class StartUp
    {
        public static void Main()
        {
            //RunFirstPart();

            //RunSecondPart();

            //RunThirdPart();

            RunLastPart();
        }

        private static void RunLastPart()
        {
            var n = int.Parse(Console.ReadLine());
            var appenders = new List<IAppender>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var layout = LayoutFactory.GetInstance(input[1]);
                var appender = AppenderFactory.GetInstance(input[0], layout);
                if (input.Length > 2)
                {
                    var reportLevel = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input[2].ToLower());
                    appender.ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);
                }
                appenders.Add(appender);
            }

            var logger = new Loger(appenders);
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command != null)
                {
                    var tokens = command.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    var loggerMethod = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tokens[0].ToLower());
                    var methodType = typeof(Loger).GetMethod(loggerMethod);
                    methodType.Invoke(logger, new object[] { tokens[1], tokens[2] });
                }
            }

            Console.WriteLine(@"Logger info");
            foreach (IAppender appender in appenders)
            {
                Console.WriteLine($"Appender type: {appender.GetType().Name}, Layout type: {appender.Layout.GetType().Name}, Report level: {appender.ReportLevel.ToString().ToUpper()}, Messages appended: {appender.File.MessageNumber}, File size {appender.File.Size}");
            }
        }

        private static void RunThirdPart()
        {
            var appenders = new List<IAppender>();
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            appenders.Add(consoleAppender);
            consoleAppender.ReportLevel = ReportLevel.Error;

            var logger = new Loger(appenders);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
        }

        private static void RunSecondPart()
        {
            var appenders = new List<IAppender>();
            var xmlLayout = new XmlLayout();
            appenders.Add(new ConsoleAppender(xmlLayout));
            var logger = new Loger(appenders);

            logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");
        }

        private static void RunFirstPart()
        {
            var appenders = new List<IAppender>();
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            appenders.Add(consoleAppender);

            var file = new LogFile();
            var fileAppender = new FileAppender(simpleLayout);
            appenders.Add(fileAppender);
            fileAppender.File = file;

            var logger = new Loger(appenders);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}