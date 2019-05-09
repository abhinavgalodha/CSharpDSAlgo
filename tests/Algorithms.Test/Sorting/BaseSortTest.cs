using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Sorting.Factory;
using Algorithms.Sorting.Interfaces;
using Algorithms.Test.Data;
using FluentAssertions;
using Xunit;

namespace Algorithms.Test.Sorting
{
    public abstract class BaseSortTest
    {
        //private ISort _sortingAlgorithm;

        protected abstract ISortingAlgorithm SortingAlgorithm { get; }

        private void IsAbleToSort<T>(CollectionVerification<T> collectionVerification) where T : IComparable<T>
        {
            new SortableCollectionVerification<T>(SortingAlgorithm, collectionVerification)
                .IsAbleToSort();
        }

        [Fact]
        public void SortingForEmptyArray()
        {
            IsAbleToSort(TestData.ArrayEmpty);
        }

        [Fact]
        public void SortingForOneElementArray()
        {
            IsAbleToSort(TestData.ArrayOneElement);

        }

        [Fact]
        public void SortingForOddCountArray()
        {
            IsAbleToSort(TestData.ArrayOddCount);
        }

        [Fact]
        public void SortingForEvenCountArray()
        {
            IsAbleToSort(TestData.ArrayEvenCount);
        }

        [Fact]
        public void SortingForDuplicateElementsInArray()
        {
            IsAbleToSort(TestData.ArrayWithDuplicateElements);
        }

        [Fact]
        public void SortingForAlreadySortedArray()
        {
            IsAbleToSort(TestData.ArrayAlreadySorted);
        }

        [Fact]
        public void SortingForReverseSortedArray()
        {
            IsAbleToSort(TestData.ArrayReverseArray);
        }

        [Fact]
        public void SortingForNumbersIncludingNegativesInArray()
        {
            IsAbleToSort(TestData.ArrayIncludingNegativeNumbers);
        }

        [Fact]
        public void SortingForSameElementRepeatedMultipleTimesInArray()
        {
            IsAbleToSort(TestData.ArrayWithSameNumberRepeating);
        }

    }
}
