namespace FestivalManager.Entities.Sets
{
    using System;

    public class Medium : Set
    {
        private const int MaxLength = 40;

        public Medium(string name)
            : base(name, new TimeSpan(0, 0, MaxLength, 0))
        {
        }
    }
}