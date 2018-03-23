using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericBox_EXER
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            this.Collection = new List<T>();
        }

        public Box(IEnumerable<T> collection)
        {
            this.Collection = new List<T>(collection);
        }

        public List<T> Collection { get; set; }

        public void Add(T element)
        {
            this.Collection.Add(element);
        }

        public void Remove(int index)
        {
            this.Collection.RemoveAt(index);
        }

        public bool Contains(T element)
        {
            return this.Collection.Contains(element);
        }

        public void SwapElements(int first, int second)
        {
            var temp = this.Collection[first];
            this.Collection[first] = this.Collection[second];
            this.Collection[second] = temp;
        }

        public int CountGreaterEmelements(T element)
        {
            return this.Collection.Count(e => e.CompareTo(element) > 0);
        }

        public T Max()
        {
            return this.Collection.Max();
        }

        public T Min()
        {
            return this.Collection.Min();
        }

        public string Print()
        {
            var result = new StringBuilder();
            foreach (var item in this.Collection)
            {
                result.AppendLine(item.ToString());
            }
            return result.ToString().Trim();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int j = 0; j < this.Collection.Count; j++)
            {
                result.AppendLine($"{this.Collection[j].GetType().FullName}: {this.Collection[j]}");
            }
            return result.ToString().Trim();
        }
    }
}