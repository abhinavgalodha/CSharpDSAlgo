using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DataStructures.Graph;
using DataStructures.Graph.Edge;
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

        [Fact]
        public void Should_Have_SelfLoop_When_Edge_Has_SelfLoop()
        {
            Edge<int> edge = new Edge<int>(1,1);

            var expectedResult = true;

            edge.IsSelfLoop().Should().BeTrue();

        }


        public void Should_Not_Have_SelfLoop_When_Edge_Has_SelfLoop()
        {
            Edge<int> edge = new Edge<int>(1,1);

            var expectedResult = false;

            edge.IsSelfLoop().Should().BeFalse();

        }


    }
}
