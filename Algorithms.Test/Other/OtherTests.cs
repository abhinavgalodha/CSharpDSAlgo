using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Algorithms.Test.Other
{
    public class OtherTests
    {
        [Fact]
        public void ReturnSmallestPositiveInteger()
        { 
            var inputArray = new int[]{ 4, 6, 5, -2, -7, 8, 3, 2, -9 };
            var expectedSmallestPositiveInteger = 2;

            var actualSmallestPositiveInteger = Others.Other.GetSmallestPositiveInteger(inputArray);
            actualSmallestPositiveInteger.Should().Be(expectedSmallestPositiveInteger);
        }
    }
}
