using System.Linq;

namespace FestivalManager.Entities
{
    using Contracts;
    using System.Collections.Generic;

    public class Stage : IStage
    {
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();
        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();
        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public IPerformer GetPerformer(string name)
        {
            return this.performers.FirstOrDefault(p => p.Name.Equals(name));
        }

        public ISong GetSong(string name)
        {
            return this.songs.FirstOrDefault(s => s.Name.Equals(name));
        }

        public ISet GetSet(string name)
        {
            return this.sets.FirstOrDefault(s => s.Name.Equals(name));
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Any(p => p.Name.Equals(name));
        }

        public bool HasSong(string name)
        {
            return this.songs.Any(s => s.Name.Equals(name));
        }

        public bool HasSet(string name)
        {
            return this.sets.Any(s => s.Name.Equals(name));
        }
    }
}