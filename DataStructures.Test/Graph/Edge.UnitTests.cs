using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DataStructures.Graph;
using FluentAssertions;

namespace DataStructures.Test.Graph
{
    public class Edge
    {
        [Fact]
        public void Should_Have_Arrow_Seperator_In_The_ToString_Representation()
        {
            Edge<int> edge = new Edge<int>(1,2);

            var expectedToString = "1->2";

            edge.ToString().Should().Be(expectedToString);

        }
    }
}
