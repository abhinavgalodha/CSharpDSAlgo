using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using DataStructures.Graph.Edge;

namespace DataStructures.Graph.Implementation
{
    public class GraphUsingAdjList<T> : BaseGraph<T>
    {
        private readonly Dictionary<T, List<T>> _adjacencyList;

        public GraphUsingAdjList()
        {
            _adjacencyList = new Dictionary<T, List<T>>();
        }

        public override void AddEdge(Edge<T> edgeToAdd)
        {
            edgeToAdd.ThrowIfNull(nameof(edgeToAdd));

            if (IsFromVertexAlreadyInAdjacencyList(_adjacencyList, edgeToAdd))
            {
                AppendToVertexInExistingListOfFromVertex(_adjacencyList, edgeToAdd);
            }
            else
            {
                AddNewFromVertexInAdjacencyDictAndAddToVertexInList(_adjacencyList, edgeToAdd);
            }

            bool IsFromVertexAlreadyInAdjacencyList(Dictionary<T, List<T>> adjacencyList, Edge<T> edgeToAdd)
            {
                var vertexTo = edgeToAdd.To;
                return adjacencyList.ContainsKey(edgeToAdd.From);
            }

            void AppendToVertexInExistingListOfFromVertex(Dictionary<T, List<T>> adjacencyList, Edge<T> edgeToAdd)
            {
                var vertexFrom = edgeToAdd.From;
                var vertexTo = edgeToAdd.To;

                List<T> listOfVerticesFromVertex = new List<T> { vertexTo };
                _adjacencyList.Add(vertexFrom, listOfVerticesFromVertex);

            }

            void AddNewFromVertexInAdjacencyDictAndAddToVertexInList(Dictionary<T, List<T>> adjacencyList, Edge<T> edgeToAdd)
            {
                var vertexFrom = edgeToAdd.From;
                var vertexTo = edgeToAdd.To;

                if (_adjacencyList.ContainsKey(vertexFrom))
                {
                    _adjacencyList[vertexFrom].Add(vertexTo);
                }
            }
        }

        public override IEnumerable<T> GetAllAdjacentVertices(T vertex)
        {
            return _adjacencyList[vertex];
        }

        public override IEnumerable<T> GetAllVertices()
        {
            var allVerticesAsKeys = _adjacencyList.Keys.Select(x => x);
            var allVerticesAsValues = _adjacencyList.Values.SelectMany(x => x);
            return allVerticesAsKeys.Union(allVerticesAsValues).Distinct();
        }

        public override IEnumerable<Edge<T>> GetAllEdges()
        {
            foreach (var fromVertexKeyValuePair in _adjacencyList)
            {
                var fromVertex = fromVertexKeyValuePair.Key;
                var toVertexList = fromVertexKeyValuePair.Value;

                foreach (var toVertex in toVertexList)
                {
                    Edge<T> edge = new Edge<T>(fromVertex, toVertex);
                    yield return edge;
                }
            }
        }

        public override bool IsCycleExists()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> DepthFirstTraversal()
        {
            // 
            var visitedTracker = new Dictionary<T, bool>(VertexCount);

            foreach (var vertexKeyValuePair in _adjacencyList)
            {
                // 1. Start with first node
                var vertex = vertexKeyValuePair.Key;
                if (!visitedTracker.ContainsKey(vertex))
                {
                    yield return (T)DepthFirstTraversalRecursive(vertex);
                }
            }

            IEnumerable<T> DepthFirstTraversalRecursive(T vertex)
            {
                visitedTracker.Add(vertex, true);
                yield return vertex;
                var adjacentVertices = GetAllAdjacentVertices(vertex);

                foreach (var adjacentVertex in adjacentVertices)
                {
                    if (visitedTracker.ContainsKey(adjacentVertex))
                    {
                        yield return (T)DepthFirstTraversalRecursive(adjacentVertex);    
                    }
                }
            }

        }
    }
}
