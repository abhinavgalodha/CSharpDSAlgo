using Algorithms.Strings;
using FluentAssertions;
using Xunit;

namespace Algorithms.Test.Strings
{
    public class SubStringSearchTests
    {
        [Fact]
        public void WhenPatternInStringThenSubstringShouldReturnTrue()
        {
            //Act
            var inputString = "ABCABCCABACCBABBAABBCCAA";
            var patternString = "AABBCC";
            
            //Arrange
            var isSubstring = SubStringSearch.Search(inputString, patternString);

            //Assert
            isSubstring.Should().BeTrue();
        }
        
        [Fact]
        public void WhenPatternNotInStringThenSubstringShouldReturnFalse()
        {
            //Act
            var inputString = "ABBCDDAABB";
            var patternString = "AABBCC";
            
            //Arrange
            var isSubstring = SubStringSearch.Search(inputString, patternString);

            //Assert
            isSubstring.Should().BeFalse();
        } 

        [Fact]
        public void WhenPatternLengthMoreThanTheStringToSearchInThenReturnFalse()
        {
            //Act
            var inputString = "ABBC";
            var patternString = "AABBCC";
            
            //Arrange
            var isSubstring = SubStringSearch.Search(inputString, patternString);

            //Assert
            isSubstring.Should().BeFalse();
        } 
    }
}
