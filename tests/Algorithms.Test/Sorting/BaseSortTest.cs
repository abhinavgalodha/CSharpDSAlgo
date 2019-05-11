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
        protected abstract ISortingAlgorithm SortingAlgorithm { get; }

        private void IsAbleToSort<T>(CollectionVerification<T> collectionVerification) where T : IComparable<T>
        {
            new SortableCollectionVerification<T>(SortingAlgorithm, collectionVerification)
                .IsAbleToSort();
        }

        [Fact]
        public void SortingForEmptyArray()
        {
            IsAbleToSort(TestDataFactory.CreateData(SortingData.ArrayEmpty));
        }

        [Fact]
        public void SortingForOneElementArray()
        {
            IsAbleToSort(TestDataFactory.CreateData(SortingData.ArrayOneElement));

        }

        [Fact]
        public void SortingForOddCountArray()
        {
            IsAbleToSort(TestDataFactory.CreateData(SortingData.ArrayOddCount));
        }

        [Fact]
        public void SortingForEvenCountArray()
        {
            IsAbleToSort(TestDataFactory.CreateData(SortingData.ArrayEvenCount));
        }

        [Fact]
        public void SortingForDuplicateElementsInArray()
        {
            IsAbleToSort(TestDataFactory.CreateData(SortingData.ArrayWithDuplicateElements));
        }

        [Fact]
        public void SortingForAlreadySortedArray()
        {
            IsAbleToSort(TestDataFactory.CreateData(SortingData.ArrayAlreadySorted));
        }

        [Fact]
        public void SortingForReverseSortedArray()
        {
            IsAbleToSort(TestDataFactory.CreateData(SortingData.ArrayReverseArray));
        }

        [Fact]
        public void SortingForNumbersIncludingNegativesInArray()
        {
            IsAbleToSort(TestDataFactory.CreateData(SortingData.ArrayIncludingNegativeNumbers));
        }

        [Fact]
        public void SortingForSameElementRepeatedMultipleTimesInArray()
        {
            IsAbleToSort(TestDataFactory.CreateData(SortingData.ArrayWithSameNumberRepeating));
        }

    }
}
