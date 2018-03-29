using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinkedListTraversal_EXER
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private readonly List<T> collection;

        public LinkedList()
        {
            this.collection = new List<T>();
        }

        public List<T> Collection => this.collection;

        public int Count
        {
            get { return this.collection.Count; }
        }

        public void Add(T item)
        {
            this.collection.Add(item);
        }

        public void Remove(T item)
        {
            var result = this.collection.FirstOrDefault(t => t.Equals(item));
            if (!result.Equals(default(T)))
            {
                this.collection.Remove(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}