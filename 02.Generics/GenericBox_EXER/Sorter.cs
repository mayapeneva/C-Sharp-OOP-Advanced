using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBox_EXER
{
    public class Sorter

    {
        public List<T> Sort<T>(Box<T> box)
            where T : IComparable<T>
        {
            var result = box.Collection.OrderBy(e => e);
            return result.ToList();
        }
    }
}