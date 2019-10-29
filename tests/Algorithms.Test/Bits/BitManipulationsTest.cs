using Algorithms.Bits;
using FluentAssertions;
using Xunit;

namespace Algorithms.Test.Bits
{
    public class BitManipulationsTest
    {
        [Fact]
        public void InsertionIntoAnotherShouldWork()
        {
            var result = BitManipulations.Insertion(100, 19, 2, 6);
            result.Should().Be(1100);

        }
    }
}
