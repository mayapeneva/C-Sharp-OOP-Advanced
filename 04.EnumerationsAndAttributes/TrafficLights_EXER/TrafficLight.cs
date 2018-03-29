using System;

namespace TrafficLights_EXER
{
    public class TrafficLight
    {
        private Light color;

        public TrafficLight(Light color)
        {
            this.color = color;
        }

        public void GetNextColor()
        {
            this.color = (Light)(((int)this.color + 1) % Enum.GetNames(typeof(Light)).Length);
        }

        public override string ToString()
        {
            return this.color.ToString();
        }
    }
}