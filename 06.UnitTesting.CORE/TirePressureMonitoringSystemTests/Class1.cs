using Moq;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TirePressureMonitoringSystemTests
{
    public class Class1
    {
        private Alarm alarm;
        private Mock<ISensor> sensorMoq;

        [SetUp]
        public void InitialTest()
        {
            this.alarm = new Alarm();
            this.sensorMoq = new Mock<ISensor>();
        }

        [Test]
        public void Alarm_RightPressure_AlarmShouldBeOff()
        {
            var ppValue = 19;
            this.sensorMoq.Setup(s => s.PopNextPressurePsiValue()).Returns(() => ppValue);
            var expected = false;

            this.alarm.Check();

            Assert.AreEqual(expected, this.alarm.AlarmOn);
        }

        [Test]
        public void Alarm_LowPressure_AlarmSholdBeOn()
        {
            var ppValue = 17;
            this.sensorMoq.Setup(s => s.PopNextPressurePsiValue()).Returns(() => ppValue);
            var expected = true;

            this.alarm.Check();

            Assert.AreEqual(expected, this.alarm.AlarmOn);
        }

        [Test]
        public void Alarm_HighPressure_AlarmSholdBeOn()
        {
            var ppValue = 21;
            this.sensorMoq.Setup(s => s.PopNextPressurePsiValue()).Returns(() => ppValue);
            var expected = true;

            this.alarm.Check();

            Assert.AreEqual(expected, this.alarm.AlarmOn);
        }

        [Test]
        public void Alarm_NegativePressure_AlarmSholdBeOn()
        {
            var ppValue = -10;
            this.sensorMoq.Setup(s => s.PopNextPressurePsiValue()).Returns(() => ppValue);
            var expected = true;

            this.alarm.Check();

            Assert.AreEqual(expected, this.alarm.AlarmOn);
        }
    }
}