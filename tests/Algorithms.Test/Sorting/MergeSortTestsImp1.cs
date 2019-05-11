using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Sorting.Factory;
using Algorithms.Sorting.Interfaces;
using FluentAssertions;
using Xunit;

namespace Algorithms.Test.Sorting
{
    [Trait("Sorting", "MergeSort Implementation 1")]
    public class MergeSortTestsImpl1 : BaseSortTest
    {
        protected override ISortingAlgorithm SortingAlgorithm => SortingFactory.Create(SortingAlgorithms.MergeSort1);
    }

    //public class MergeSortTestsImpl2
    //{
    //    [Fact]
    //    public void SortingForEmptyArray()
    //    {
    //        // Arrange
    //        int[] listEmpty = new int[0];

    //        // Act
    //        Algorithms.Sorting.MergeSort.Implementation2.Sort(listEmpty);

    //        // Assert
    //        listEmpty.Should().BeEmpty();

    //    }

    //    [Fact]
    //    public void SortingForOneElementArray()
    //    {
    //        // Arrange
    //        List<int> listOneElement = new List<int>(){5};

    //        // Act
    //        Algorithms.Sorting.MergeSort.Implementation2.Sort(listOneElement.ToArray());

    //        // Assert
    //        listOneElement.Should().HaveCount(1);

    //    }

    //    [Fact]
    //    public void SortingForOddCountArray()
    //    {
    //        // Arrange
    //        var listOddCount = new int[]{4,12,1,3,9,7,2};

    //        // Act
    //        Algorithms.Sorting.MergeSort.Implementation2.Sort(listOddCount);

    //        // Assert
    //        var expectedList = new int[]{ 1,2,3,4,7,9,12};
    //        listOddCount.Should().BeEquivalentTo(expectedList);

    //    }

    //    [Fact]
    //    public void SortingForEvenCountArray()
    //    {
    //        // Arrange
    //        var listEvenCount = new int[]{4,12,1,3,9,7,2};

    //        // Act
    //        Algorithms.Sorting.MergeSort.Implementation2.Sort(listEvenCount);

    //        // Assert
    //        var expectedList = new int[]{ 1,2,3,4,7,9,12};
    //        listEvenCount.Should().BeEquivalentTo(expectedList);

    //    }

    //    [Fact]
    //    public void SortingForDuplicateElementsInArray()
    //    {
    //        // Arrange
    //        var listWithDuplicateElements = new int[]{4,12,4,4,9,7};

    //        // Act
    //        Algorithms.Sorting.MergeSort.Implementation2.Sort(listWithDuplicateElements);

    //        // Assert
    //        var expectedList = new int[] { 4,4,4,7,9,12};
    //        listWithDuplicateElements.Should().BeEquivalentTo(expectedList);

    //    }

    //    [Fact]
    //    public void SortingForAlreadySortedArray()
    //    {
    //        // Arrange
    //        var listAlreadySorted = new int[]{4, 6, 10, 12, 15, 23, 28, 35};

    //        // Act
    //        Algorithms.Sorting.MergeSort.Implementation2.Sort(listAlreadySorted);

    //        // Assert
    //        var expectedList = new int[] { 4, 6, 10, 12, 15, 23, 28, 35};
    //        listAlreadySorted.Should().BeEquivalentTo(expectedList);

    //    }

    //    [Fact]
    //    public void SortingForReverseSortedArray()
    //    {
    //        // Arrange
    //        var listReverseArray = new int[]{35, 28, 23, 15, 12, 10, 6, 4};

    //        // Act
    //        Algorithms.Sorting.MergeSort.Implementation2.Sort(listReverseArray);

    //        // Assert
    //        var expectedList = new int[] { 4, 6, 10, 12, 15, 23, 28, 35};
    //        listReverseArray.Should().BeEquivalentTo(expectedList);

    //    }

    //    [Fact]
    //    public void SortingForNumbersIncludingNegativesInArray()
    //    {
    //        // Arrange
    //        var listIncludingNegativeNumbers = new int[] {12, 15, -23, -4 , 6, 10, -35, 28};

    //        // Act
    //        Algorithms.Sorting.MergeSort.Implementation2.Sort(listIncludingNegativeNumbers);

    //        // Assert
    //        var expectedList = new int[] { -4, -23, -35, 6, 10, 12, 15 ,28};
    //        listIncludingNegativeNumbers.Should().BeEquivalentTo(expectedList);

    //    }

    //    [Fact]
    //    public void SortingForSameElementRepeatedMultipleTimesInArray()
    //    {
    //        // Arrange
    //        var listWithRepeatingNumbers = new int[] {12, 12, 12, 12, 12};

    //        // Act
    //        Algorithms.Sorting.MergeSort.Implementation2.Sort(listWithRepeatingNumbers);

    //        // Assert
    //        var expectedList = new int[] {12, 12, 12, 12, 12};
    //        listWithRepeatingNumbers.Should().BeEquivalentTo(expectedList);

    //    }

    //}
}
