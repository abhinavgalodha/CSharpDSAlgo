using System.Collections.Generic;
using DataStructures.Graph;
using FluentAssertions;
using Xunit;
using System.Linq;

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

        [Fact]
        public void Should_Add_Edge_InGraph()
        {
            BaseGraph<int> graph = new GraphUsingArray<int>();
            graph.AddEdge(1, 2);
            graph.GetAllEdges().Any(x => x.Source == 1 && x.Destination == 2).Should().BeTrue();
        }


        [Fact]
        public void Should_Return_All_Vertices_FromGraph()
        {
            BaseGraph<int> graph = new GraphUsingArray<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);

            var listOfExpectedVertices = new List<int>() {1, 2, 3};

            graph.GetAllVertices().Should().BeEquivalentTo(listOfExpectedVertices);
        }


    }
}
