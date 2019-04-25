﻿using System;
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
            Algorithms.Sorting.MergeSort.Implementation1.Sort(listEmpty);

            // Assert
            listEmpty.Should().BeEmpty();

        }

        [Fact]
        public void SortingForOneElementArray()
        {
            // Arrange
            List<int> listOneElement = new List<int>(){5};

            // Act
            Algorithms.Sorting.MergeSort.Implementation1.Sort(listOneElement);

            // Assert
            listOneElement.Should().HaveCount(1);

        }

        [Fact]
        public void SortingForOddCountArray()
        {
            // Arrange
            List<int> listOddCount = new List<int>(){4,12,1,3,9,7,2};

            // Act
            Algorithms.Sorting.MergeSort.Implementation1.Sort(listOddCount);

            // Assert
            var expectedList = new List<int>() { 1,2,3,4,7,9,12};
            listOddCount.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForEvenCountArray()
        {
            // Arrange
            List<int> listEvenCount = new List<int>(){4,12,1,3,9,7};

            // Act
            Algorithms.Sorting.MergeSort.Implementation1.Sort(listEvenCount);

            // Assert
            var expectedList = new List<int>() { 1,3,4,7,9,12};
            listEvenCount.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForDuplicateElementsInArray()
        {
            // Arrange
            List<int> listWithDuplicateElements = new List<int>(){4,12,4,4,9,7};

            // Act
            Algorithms.Sorting.MergeSort.Implementation1.Sort(listWithDuplicateElements);

            // Assert
            var expectedList = new List<int>() { 4,4,4,7,9,12};
            listWithDuplicateElements.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForAlreadySortedArray()
        {
            // Arrange
            List<int> listAlreadySorted = new List<int>(){4, 6, 10, 12, 15, 23, 28, 35};

            // Act
            Algorithms.Sorting.MergeSort.Implementation1.Sort(listAlreadySorted);

            // Assert
            var expectedList = new List<int>() { 4, 6, 10, 12, 15, 23, 28, 35};
            listAlreadySorted.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForReverseSortedArray()
        {
            // Arrange
            List<int> listReverseArray = new List<int>(){35, 28, 23, 15, 12, 10, 6, 4};

            // Act
            Algorithms.Sorting.MergeSort.Implementation1.Sort(listReverseArray);

            // Assert
            var expectedList = new List<int>() { 4, 6, 10, 12, 15, 23, 28, 35};
            listReverseArray.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForNumbersIncludingNegativesInArray()
        {
            // Arrange
            List<int> listIncludingNegativeNumbers = new List<int>(){12, 15, -23, -4 , 6, 10, -35, 28};

            // Act
            Algorithms.Sorting.MergeSort.Implementation1.Sort(listIncludingNegativeNumbers);

            // Assert
            var expectedList = new List<int>() { -4, -23, -35, 6, 10, 12, 15 ,28};
            listIncludingNegativeNumbers.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void SortingForSameElementRepeatedMultipleTimesInArray()
        {
            // Arrange
            List<int> listWithRepeatingNumbers = new List<int>() {12, 12, 12, 12, 12};

            // Act
            Algorithms.Sorting.MergeSort.Implementation1.Sort(listWithRepeatingNumbers);

            // Assert
            var expectedList = new List<int>() {12, 12, 12, 12, 12};
            listWithRepeatingNumbers.Should().BeEquivalentTo(expectedList);

        }

    }
}
