using LambdaCore_Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaCore_Skeleton.Collection
{
    public class LStack
    {
        private readonly LinkedList<ICore> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<ICore>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public ICore Push(ICore item)
        {
            this.innerList.AddLast(item);
            return item;
        }

        public void Pop()
        {
            this.innerList.RemoveLast();
        }

        public ICore Peek()
        {
            ICore peekedItem = this.innerList.First();
            return peekedItem;
        }

        public Boolean IsEmpty()
        {
            return this.innerList.Count > 0;
        }
    }
}