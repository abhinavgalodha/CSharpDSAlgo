using System.Collections.Generic;
using Algorithms.Strings;
using FluentAssertions;

namespace Algorithms.Test.Strings
{
    public class PermutationsOfAStringTests
    {
        [Fact]
        public void PermutationsOf3Words()
        {
            //Act
            var inputString = "ABC";
            var expectedPermutations = new List<string>()
            {
                "ABC",
                "ACB",
                "BAC",
                "BCA",
                "CAB",
                "CBA",
            };
            
            //Arrange
            var outputPermutations = PermutationsOfAString.Create(inputString);

            //Assert
            outputPermutations.Should().BeEquivalentTo(expectedPermutations);
        } 
    }
}
