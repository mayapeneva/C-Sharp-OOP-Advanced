using System;
using System.Collections.Generic;

namespace TrafficLights_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var trafficLights = new List<TrafficLight>();
            foreach (var signal in input)
            {
                var initialColor = (Light)Enum.Parse(typeof(Light), signal);
                trafficLights.Add(new TrafficLight(initialColor));
            }

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                foreach (var traficLight in trafficLights)
                {
                    traficLight.GetNextColor();
                }

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}