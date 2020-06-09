using DataStructures.Graph;
using DataStructures.Graph.Implementation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataStructures.Test.Graph
{
    public class DirectedGraphTests
    {
        [Fact]
        public void ShouldReturnTopologicalSortOrder_WhenGraphIsDAG_AndContainsEdges()
        { 
            BaseGraph<int> digraph = new GraphUsingAdjList<int>();
            digraph.AddEdge(0,5);
            digraph.AddEdge(0,2);
            digraph.AddEdge(3,6);
            digraph.AddEdge(3,5);
            digraph.AddEdge(3,4);
            digraph.AddEdge(5,2);
            digraph.AddEdge(6,4);
            digraph.AddEdge(6,0);
            digraph.AddEdge(3,2);
            digraph.AddEdge(1,4);


            var actualResult = digraph.TopologicalSort();
            var expectedResult = new List<int> { 3, 6, 0, 5, 2, 1, 4};
            actualResult.Should().BeEquivalentTo(expectedResult, options => options.WithStrictOrdering());

        }
    }
}
