using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting.Interfaces
{
    public interface ISort
    {
        /// <summary>
        /// Sort any Type which implements IComparable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        void Sort<T>(ICollection<T> collection) where T : IComparable<T>;
    }
}
