using System.Collections.Generic;
using DataStructures.Graph;
using FluentAssertions;
using Xunit;
using System.Linq;
using DataStructures.Graph.Implementation;

namespace DataStructures.Test.Graph
{
    public class GraphUsingArrayUnitTests
    {
        [Fact]
        public void Should_Have_5_Vertices_When_4_Edges_Added_ToConnectAllVertices_InGraph()
        {
            BaseGraph<int> graph = new GraphUsingArrayOfEdges<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);
            graph.NumberOfVertices.Should().Be(5);
        }

        [Fact]
        public void Should_Have_4_Edges_When_4_Edges_Added_InGraph()
        {
            BaseGraph<int> graph = new GraphUsingArrayOfEdges<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);
            graph.NumberOfEdges.Should().Be(4);
        }

        [Fact]
        public void Should_Add_Edge_InGraph()
        {
            BaseGraph<int> graph = new GraphUsingArrayOfEdges<int>();
            graph.AddEdge(1, 2);
            graph.GetAllEdges().Any(x => x.From == 1 && x.To == 2).Should().BeTrue();
        }


        [Fact]
        public void Should_Return_All_Vertices_FromGraph()
        {
            BaseGraph<int> graph = new GraphUsingArrayOfEdges<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);

            var listOfExpectedVertices = new List<int>() {1, 2, 3};

            graph.GetAllVertices().Should().BeEquivalentTo(listOfExpectedVertices);
        }

        [Fact]
        public void Should_Have_SeperatorIn_ToStringRepresentation_OfGraph()
        {
            BaseGraph<int> graph = new GraphUsingArrayOfEdges<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);

            var expectedToString = "1->2 , 2->3";

            graph.ToString().Should().Be(expectedToString);
        }


    }
}
