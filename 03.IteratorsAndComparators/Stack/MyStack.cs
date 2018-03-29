using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private readonly List<T> collection;

        public MyStack()
        {
            this.collection = new List<T>();
        }

        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                this.collection.Add(item);
            }
        }

        public void Pop()
        {
            var count = this.collection.Count;
            if (count != 0)
            {
                this.collection.RemoveAt(count - 1);
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.collection.Count - 1; i >= 0; i--)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}