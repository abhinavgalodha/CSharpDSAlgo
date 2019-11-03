using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.Graph;
using FluentAssertions;
using Xunit;

namespace DataStructures.Test.Graph
{
    public class Graph
    {
        [Fact]
        public void Should_Have_5_Vertices_When_5_Vertices_Added_InGraph()
        {
            BaseGraph<int> graph = new GraphUsingArray<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);
            graph.NumberOfVertices.Should().Be(5);
        }

        [Fact]
        public void Should_Have_4_Edges_When_4_Edges_Added_InGraph()
        {
            BaseGraph<int> graph = new GraphUsingArray<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);
            graph.NumberOfEdges.Should().Be(4);
        }
    }
}
