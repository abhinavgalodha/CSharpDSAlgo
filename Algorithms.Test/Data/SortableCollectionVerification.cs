using Algorithms.Sorting.Interfaces;
using System;
using System.Collections.Generic;

namespace Algorithms.Test.Data
{
    internal class SortableCollectionVerification<T> : CollectionVerification<T> where T : IComparable<T>
    {
        private readonly ISort _sortingAlgorithm;

        public SortableCollectionVerification(ISort sortingAlgorithm, ICollection<T> actual, ICollection<T> expected):
            base(actual, expected)
        {
            this._sortingAlgorithm = sortingAlgorithm;
        }

        public SortableCollectionVerification(ISort sortingAlgorithm, CollectionVerification<T> collectionVerification):
            base(collectionVerification.Actual, collectionVerification.Expected)
        {
            this._sortingAlgorithm = sortingAlgorithm;
        }

        public bool IsAbleToSort()
        {
            _sortingAlgorithm.Sort(this.Actual);
            return IsEqual();
        }
    }


}
