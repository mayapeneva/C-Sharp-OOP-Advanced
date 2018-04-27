using Logger.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public static ILayout GetInstance(string layoutType)
        {
            var layout = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(l => l.Name == layoutType);

            return (ILayout)Activator.CreateInstance(layout);
        }
    }
}