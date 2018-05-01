using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    [TestFixture]
    public class SetControllerTests
    {
        private IStage stage;
        private ISetController controller;

        [SetUp]
        public void InitialTest()
        {
            this.stage = new Stage();
            this.controller = new SetController(this.stage);
        }

        [Test]
        public void PerformSets_ShouldReturnCorrectMessage()
        {
            var set1 = new Short("Short");
            var set2 = new Medium("Medium");
            var set3 = new Long("Long");
            this.stage.AddSet(set1);
            this.stage.AddSet(set2);
            this.stage.AddSet(set3);

            var perf1 = new Performer("Pesho", 23);
            perf1.AddInstrument(new Guitar());
            var perf2 = new Performer("Ivan", 24);
            perf2.AddInstrument(new Drums());
            var perf3 = new Performer("Gosho", 25);
            perf3.AddInstrument(new Microphone());
            set3.AddPerformer(perf1);
            set3.AddPerformer(perf3);
            set2.AddPerformer(perf2);

            var song1 = new Song("Wave", new TimeSpan(0, 0, 01, 01));
            var song2 = new Song("Fair", new TimeSpan(0, 0, 02, 02));
            var song3 = new Song("Life", new TimeSpan(0, 0, 03, 03));
            set3.AddSong(song1);
            set3.AddSong(song2);
            set3.AddSong(song3);

            var expected = new StringBuilder();
            expected.AppendLine("1. Long:");
            expected.AppendLine("-- 1. Wave (01:01)");
            expected.AppendLine("-- 2. Fair (02:02)");
            expected.AppendLine("-- 3. Life (03:03)");
            expected.AppendLine("-- Set Successful");
            expected.AppendLine("2. Medium:");
            expected.AppendLine("-- Did not perform");
            expected.AppendLine("3. Short:");
            expected.AppendLine("-- Did not perform");

            var result = this.controller.PerformSets();

            Assert.AreEqual(expected.ToString().Trim(), result);
        }

        [Test]
        public void PerformSets_CanPerform_InstrumentWearsDown()
        {
            var set = new Long("Long");
            set.AddSong(new Song("Wave", new TimeSpan(0, 0, 01, 01)));
            var performer = new Performer("Pesho", 23);
            var instrument = new Guitar();
            performer.AddInstrument(instrument);
            set.AddPerformer(performer);
            this.stage.AddSet(set);
            var expected = 40;

            this.controller.PerformSets();

            var result = instrument.Wear;

            Assert.AreEqual(expected, result);
        }
    }
}