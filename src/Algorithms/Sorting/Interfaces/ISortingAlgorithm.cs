using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting.Interfaces
{
    public interface ISortingAlgorithm
    {
        /// <summary>
        /// Sort any Type which implements IComparable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        void Sort<T>(IList<T> collection) where T : IComparable<T>;

        //
        // IList is used to modify the collection and you care about the ordering and / or positioning of the elements in the collection.
        // IEnumerable isn't used as the Count Property needs to be read, which can be a performance penalty in IEnumerable,
        // as well the collections could be modified.
        // 
        // Any Implementation can use any internal list implementation
    }
}
