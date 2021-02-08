using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Graph;
using DataStructures.Graph.Implementation;
using FluentAssertions;
using Xunit;

namespace DataStructures.Test.Graph
{
    public class BaseGraphTests
    {
        [Fact]
        public void Should_Have_Correct_Graph_DFS_Traversal_When_More_ThanOne_ConnectedVertices()
        {
            BaseGraph<int> graph = new GraphUsingAdjList<int>();
            graph.AddEdge(0, 1);  
            graph.AddEdge(0, 2);  
            graph.AddEdge(1, 2);  
            graph.AddEdge(2, 0);  
            graph.AddEdge(2, 3);  
            graph.AddEdge(3, 3);

            var vertices = graph.IterateDepthFirst;
            var actualVertices = vertices.ToList();
            var expectedVertices = new List<int> { 0, 1, 2, 3};

            actualVertices.Should().BeEquivalentTo(expectedVertices, options => options.WithStrictOrdering());
        }

        [Fact(Skip ="Not Complete")]
        public void Should_Have_Correct_Graph_DFS_Traversal_UsingStack_When_More_ThanOne_ConnectedVertices()
        {
            BaseGraph<int> graph = new GraphUsingAdjList<int>();
            graph.AddEdge(0, 2);  
            graph.AddEdge(0, 3);  
            graph.AddEdge(1, 0);  
            graph.AddEdge(1, 4);  
            graph.AddEdge(2, 1);

            var vertices = graph.IterateDepthFirst;
            var actualVertices = vertices.ToList();
            var expectedVertices = new List<int> { 0, 3, 2, 1, 4};

            actualVertices.Should().BeEquivalentTo(expectedVertices, options => options.WithStrictOrdering());
        }


    }
}
