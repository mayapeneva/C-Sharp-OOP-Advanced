using Logger.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        public static IAppender GetInstance(string appenderType, ILayout layout)
        {
            var appender = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(a => a.Name == appenderType);

            return (IAppender)Activator.CreateInstance(appender, layout);
        }
    }
}