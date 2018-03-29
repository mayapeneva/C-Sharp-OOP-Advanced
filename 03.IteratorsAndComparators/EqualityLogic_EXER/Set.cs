using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic_EXER
{
    public class Set<Person>
    {
        private readonly List<Person> set;

        public Set(List<Person> set)
        {
            this.set = set;
        }

        public void Insert(Person newPerson)
        {
            if (!this.Contains(newPerson))
            {
                this.set.Add(newPerson);
            }
        }

        public bool Contains(Person newPerson)
        {
            return this.set.Any(p => p.Equals(newPerson));
        }
    }
}