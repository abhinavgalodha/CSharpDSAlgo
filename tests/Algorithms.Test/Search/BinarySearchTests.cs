using Algorithms.Search;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Algorithms.Test.Search
{
    public class BinarySearchTests
    {
        private static IEnumerable<object[]> PositiveTestData { get; } = new List<object[]>
        {
            new object[] { new int[]{ 1,2,3 } , 2, 1},
            new object[] { new int[]{ 1,2,3, 4 } , 2, 1},
            new object[] { new int[]{ 1,2,3, 4 } , 4, 3},
            new object[] { new int[]{ 1 } , 1, 0},
            new object[] { new int[]{-5,-4, -2 } , -2, 2},
            new object[] { new int[]{1,2,2,3,3,4 } , 2, 1},
        };

        private static IEnumerable<object[]> NegativeTestData { get; } = new List<object[]>
        {
            new object[] { new int[]{ } , 2, -1},
            new object[] { null , 2, -1},
            new object[] { new int[]{ 1,2,3 } , 10, -1},
            new object[] { new int[]{-2,-4, -5 } , -10, -1},
        };

        public static IEnumerable<Object[]> TestData = PositiveTestData.Union(NegativeTestData);

        [Theory]
        [MemberData(nameof(TestData))]
        public void SearchUsingBinarySearch(int[] inputArrayOfInts, int elementToFind, int expectedIndex)
        {
            var searchedElementIndex = BinarySearch.Search(inputArrayOfInts, elementToFind);
            searchedElementIndex.Should().Be(expectedIndex);
        }
    }
}
