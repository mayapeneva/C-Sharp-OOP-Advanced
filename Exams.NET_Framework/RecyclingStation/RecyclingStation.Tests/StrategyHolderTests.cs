using NUnit.Framework;
using RecyclingStation.Models.DisposalStrategies;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Tests
{
    [TestFixture]
    public class StrategyHolderTests
    {
        private IGarbageDisposalStrategy strategy;

        [SetUp]
        public void InitialTest()
        {
            this.strategy = new RecyclableDisposalStrategy();
        }

        [Test]
        public void IfPropertyIsReadOnly()
        {
            var wasteType = typeof(DisposableAttribute);
            var sysUT = new StrategyHolderTests();
        }

        [Test]
        public void AddStrategy()
        {
            var wasteType = typeof(DisposableAttribute);
            var sysUT = new StrategyHolderTests();
        }

        [Test]
        public void AddTheSameStrategyFewTimesAndCheckCount()
        {
            var sysUT = new StrategyHolderTests();
        }

        [Test]
        public void AddTheDifferentStrategiesAndCheckCount()
        {
            var sysUT = new StrategyHolderTests();
        }

        [Test]
        public void RemoveStrategy()
        {
            var sysUT = new StrategyHolderTests();
        }

        [Test]
        public void RemoveStrategies()
        {
            var sysUT = new StrategyHolderTests();
        }
    }
}