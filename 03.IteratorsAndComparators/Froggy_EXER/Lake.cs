using System.Collections;
using System.Collections.Generic;

namespace Froggy_EXER
{
    public class Lake<T> : IEnumerable<T>
    {
        private readonly List<T> stones;

        public Lake(List<T> stones)
        {
            this.stones = new List<T>(stones);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                yield return this.stones[i];
            }

            var lastOddIndex = (this.stones.Count - 1) % 2 == 0 ? this.stones.Count - 2 : this.stones.Count - 1;
            for (int j = lastOddIndex; j > 0; j -= 2)
            {
                yield return this.stones[j];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //private class StonesEnumerator<T> : IEnumerator<T>
        //{
        //    private int currentIndex;
        //    private readonly IList<T> stones;
        //
        //    public StonesEnumerator(IList<T> stones)
        //    {
        //        this.Reset();
        //        this.stones = stones;
        //    }
        //
        //    public T Current => this.Current;
        //
        //    object IEnumerator.Current => this.Current;
        //
        //    public void Dispose()
        //    {
        //    }
        //
        //    public bool MoveNext()
        //    {
        //        this.currentIndex += 2;
        //        return this.currentIndex < this.stones.Count;
        //    }
        //
        //    public void Reset()
        //    {
        //        this.currentIndex = -2;
        //    }
        //}
    }
}