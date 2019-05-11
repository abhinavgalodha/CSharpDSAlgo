using Algorithms.Sorting;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Algorithms.Test.Sorting
{
    [Trait("Algorithms", "Quick Select")]
    public class QuickSelectTests
    {
        [Fact(Skip = "NotComplete")]
        public void Find3rdLargestInArray()
        {
            var inputArray = new int[] {32, 89, 1, 4, 10 };
            var inputArray1 = new int[] {3, 89, 1, 4, 10 };

            // Assert.Equal(inputArray, inputArray1);

            inputArray.Should().BeEquivalentTo(inputArray1);


            //var expectedValue = 10;

            //var actualValue = QuickSelect.Find(inputArray, 3);

            //actualValue.Should().Be(expectedValue);
        }

        [Fact(Skip = "NotComplete")]
        public void FindElementAtFirstShouldReturnSmallestElement()
        {
            var inputArray = new int[] {32, 89, 1, 4, 10 };

            var expectedValue = 1;

            var actualValue = QuickSelect.Find(inputArray, 1);

            actualValue.Should().Be(expectedValue);
        }


        [Fact(Skip = "NotComplete")]
        public void FindElementAtLastShouldReturnLargestElement()
        {
            var inputArray = new int[] {-32, -89, 1, -4, -10 };

            var expectedValue = 1;

            var actualValue = QuickSelect.Find(inputArray, 5);

            actualValue.Should().Be(expectedValue);
        }

        [Fact(Skip = "NotComplete")]
        public void FindElementOutOfRangeShouldThrowException()
        {
            var inputArray = new int[] {32, 89, 1, 4, 10 };

            Action action = () => QuickSelect.Find(inputArray , 9);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        
    }
}
