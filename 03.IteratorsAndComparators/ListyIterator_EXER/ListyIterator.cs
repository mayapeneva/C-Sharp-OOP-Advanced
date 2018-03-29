using System;
using System.Collections;
using System.Collections.Generic;

namespace ListyIterator_EXER
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly IList<T> collection;
        private int internalIndex;

        public ListyIterator(params T[] collection)
        {
            this.collection = collection;
            this.internalIndex = 0;
        }

        public bool Move()
        {
            if (this.internalIndex < this.collection.Count - 1)
            {
                this.internalIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext() => this.internalIndex < this.collection.Count - 1;

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            if (this.internalIndex < this.collection.Count)
            {
                Console.WriteLine(this.collection[this.internalIndex]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in this.collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}