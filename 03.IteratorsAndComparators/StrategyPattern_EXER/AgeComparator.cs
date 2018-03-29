using System.Collections.Generic;

namespace StrategyPattern_EXER
{
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}