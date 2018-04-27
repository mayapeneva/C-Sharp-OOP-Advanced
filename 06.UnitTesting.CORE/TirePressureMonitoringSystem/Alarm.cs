namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly Sensor _sensor = new Sensor();

        private bool _alarmOn = false;

        public void Check()
        {
            double psiPressureValue = this._sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                this._alarmOn = true;
            }
        }

        public bool AlarmOn => this._alarmOn;
    }
}