using FestivalManager.Core.IO;
using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;
using System.Text;

namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;

    public class FestivalController : IFestivalController
    {
        private readonly IStage stage;
        private readonly ISetFactory setFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly ISongFactory songFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.setFactory = new SetFactory();
            this.performerFactory = new PerformerFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.songFactory = new SongFactory();
        }

        public string RegisterSet(string[] args)
        {
            var name = args[0];
            var type = args[1];
            var set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return string.Format(Constants.SetRegistered, type);
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);
            var performer = this.performerFactory.CreatePerformer(name, age);

            for (int i = 2; i < args.Length; i++)
            {
                var instrument = this.instrumentFactory.CreateInstrument(args[i]);
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(Constants.PerformerRegistered, name);
        }

        public string RegisterSong(string[] args)
        {
            var name = args[0];
            var time = args[1].Split(':');
            var duration = new TimeSpan(0, 0, int.Parse(time[0]), int.Parse(time[1]));
            var song = this.songFactory.CreateSong(name, duration);
            this.stage.AddSong(song);

            return string.Format(Constants.SongRegistered, name, duration);
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];
            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidSet));
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidSong));
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return string.Format(Constants.SongAddedToSet, songName, song.Duration, setName);
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidPerformer));
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidSet));
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return string.Format(Constants.PerformerAddedToSet, performerName, setName);
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return string.Format(Constants.InstrumentsRepaired, instrumentsToRepair.Length);
        }

        public string ProduceReport()
        {
            var result = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            var totalMinutes = totalFestivalLength.Minutes == 0 ? totalFestivalLength.Hours * 60 : totalFestivalLength.Minutes;
            result.AppendLine(string.Format(Constants.FestivalLength, totalMinutes, totalFestivalLength.Seconds));

            foreach (var set in this.stage.Sets)
            {
                var setMinutes = set.ActualDuration.Minutes == 0 ? set.ActualDuration.Hours * 60 : set.ActualDuration.Minutes;
                result.AppendLine(String.Format(Constants.SetDetails, set.Name, setMinutes, set.ActualDuration.Seconds));

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result.AppendLine(string.Format(Constants.PerformerDetails, performer.Name, string.Join(", ", instruments)));
                }

                if (!set.Songs.Any())
                {
                    result.AppendLine(string.Format(Constants.NoSongs));
                }
                else
                {
                    result.AppendLine(string.Format(Constants.SongsPlayed));
                    foreach (var song in set.Songs)
                    {
                        result.AppendLine(string.Format(Constants.SongDetails, song.Name, song.Duration));
                    }
                }
            }

            return result.ToString().Trim();
        }
    }
}