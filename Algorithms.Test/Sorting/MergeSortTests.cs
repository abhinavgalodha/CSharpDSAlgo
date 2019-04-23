using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Algorithms.Test.Sorting
{
    public class MergeSortTests
    {
        [Fact]
        public void SortingForEmptyArray()
        {
            // Arrange
            List<int> listEmpty = new List<int>();

            // Act
            var result = Algorithms.Sorting.MergeSort.Implementation1.Sort(listEmpty);

            // Assert
            result.Should().BeEmpty();

        }

        [Fact]
        public void SortingForOneElementArray()
        {
            // Arrange
            List<int> listEmpty = new List<int>(){5};

            // Act
            var result = Algorithms.Sorting.MergeSort.Implementation1.Sort(listEmpty);

            // Assert
            result.Should().HaveCount(1);

        }

        [Fact]
        public void SortingForOddCountArray()
        {
            // Arrange
            List<int> listEmpty = new List<int>(){4,12,1,3,9,7,2};

            // Act
            var result = Algorithms.Sorting.MergeSort.Implementation1.Sort(listEmpty);

            // Assert
            var expectedList = new List<int>() { 1,2,3,4,7,9,12};
            result.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForEvenCountArray()
        {
            // Arrange
            List<int> listEmpty = new List<int>(){4,12,1,3,9,7};

            // Act
            var result = Algorithms.Sorting.MergeSort.Implementation1.Sort(listEmpty);

            // Assert
            var expectedList = new List<int>() { 1,3,4,7,9,12};
            result.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForDuplicateElementsInArray()
        {
            // Arrange
            List<int> listEmpty = new List<int>(){4,12,4,4,9,7};

            // Act
            var result = Algorithms.Sorting.MergeSort.Implementation1.Sort(listEmpty);

            // Assert
            var expectedList = new List<int>() { 4,4,4,7,9,12};
            result.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForAlreadySortedArray()
        {
            // Arrange
            List<int> listEmpty = new List<int>(){4, 6, 10, 12, 15, 23, 28, 35};

            // Act
            var result = Algorithms.Sorting.MergeSort.Implementation1.Sort(listEmpty);

            // Assert
            var expectedList = new List<int>() { 4, 6, 10, 12, 15, 23, 28, 35};
            result.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForReverseSortedArray()
        {
            // Arrange
            List<int> list = new List<int>(){35, 28, 23, 15, 12, 10, 6, 4};

            // Act
            var result = Algorithms.Sorting.MergeSort.Implementation1.Sort(list);

            // Assert
            var expectedList = new List<int>() { 4, 6, 10, 12, 15, 23, 28, 35};
            result.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForNumbersIncludingNegativesInArray()
        {
            // Arrange
            List<int> list = new List<int>(){12, 15, -23, -4 , 6, 10, -35, 28};

            // Act
            var result = Algorithms.Sorting.MergeSort.Implementation1.Sort(list);

            // Assert
            var expectedList = new List<int>() { -4, -23, -35, 6, 10, 12, 15 ,28};
            result.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForSameElementRepeatedMultipleTimesInArray()
        {
            // Arrange
            List<int> list = new List<int>() {12, 12, 12, 12, 12};

            // Act
            var result = Algorithms.Sorting.MergeSort.Implementation1.Sort(list);

            // Assert
            var expectedList = new List<int>() {12, 12, 12, 12, 12};
            result.Should().BeEquivalentTo(expectedList);

        }

    }
}
