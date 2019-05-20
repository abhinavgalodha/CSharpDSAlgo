using Algorithms.Others;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Algorithms.Test.Other
{
    public class StringReverseTests
    {
        [Fact]
        public void ReverseStringForInputString()
        {
            //Act
            var inputString = "MyNameIsAbhinav";
            var expectedString = "vanihbAsIemaNyM";

            //Arrange
            var outputString = StringReverse.Reverse(inputString);
            

            //Assert
            outputString.Should().BeEquivalentTo(expectedString);
        }


        [Fact]
        public void ReverseStringForEmptyString()
        {
            //Act
            var inputString = string.Empty;
            var expectedString = string.Empty;

            //Arrange
            var outputString = StringReverse.Reverse(inputString);
            

            //Assert
            outputString.Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void ReverseStringForEvenElementString()
        {
            //Act
            var inputString = "AbhinavG";
            var expectedString = "GvanihbA";

            //Arrange
            var outputString = StringReverse.Reverse(inputString);
            

            //Assert
            outputString.Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void ReverseStringForOddElementString()
        {
            //Act
            var inputString = "Abhinav";
            var expectedString = "vanihbA";

            //Arrange
            var outputString = StringReverse.Reverse(inputString);
            

            //Assert
            outputString.Should().BeEquivalentTo(expectedString);
        }


        [Fact]
        public void ReverseStringWithSpaces()
        {
            //Act
            var inputString = "This is Abhinav Galodha";
            var expectedString = "ahdolaG vanihbA si sihT";

            //Arrange
            var outputString = StringReverse.Reverse(inputString);
            

            //Assert
            outputString.Should().BeEquivalentTo(expectedString);
        }


        [Fact]
        public void ReverseStringForOneElementString()
        {
            //Act
            var inputString = "A";
            var expectedString = "A";

            //Arrange
            var outputString = StringReverse.Reverse(inputString);
            

            //Assert
            outputString.Should().BeEquivalentTo(expectedString);
        }

        
    }
}
