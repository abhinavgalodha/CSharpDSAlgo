using Algorithms.Sorting.Interfaces;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.Test.Data
{
    internal class SortableCollectionVerification<T> : CollectionVerification<T> where T : IComparable<T>
    {
        private readonly ISortingAlgorithm _sortingAlgorithm;

        public SortableCollectionVerification(ISortingAlgorithm sortingAlgorithm, 
            IList<T> actual,
            IList<T> expected):
            base(actual, expected)
        {
            this._sortingAlgorithm = sortingAlgorithm;
        }

        public SortableCollectionVerification(ISortingAlgorithm sortingAlgorithm, 
            CollectionVerification<T> collectionVerification):
            base(collectionVerification.Actual, collectionVerification.Expected)
        {
            this._sortingAlgorithm = sortingAlgorithm;
        }

        public void IsAbleToSort()
        {
            _sortingAlgorithm.Sort(this.Actual);
            this.Actual.Should().BeEquivalentTo(this.Expected, options => options.WithStrictOrdering());
        }
    }


}
