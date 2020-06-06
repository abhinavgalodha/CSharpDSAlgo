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

        public override int NumberOfVertices => _adjacencyList.Count;

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

                var listOfNeighbors = _adjacencyList[vertexFrom];
                listOfNeighbors.Add(vertexTo);
            }

            void AddNewFromVertexInAdjacencyDictAndAddToVertexInList(Dictionary<T, List<T>> adjacencyList, Edge<T> edgeToAdd)
            {
                var vertexFrom = edgeToAdd.From;
                var vertexTo = edgeToAdd.To;

                _adjacencyList.Add(vertexFrom, new List<T>() { vertexTo });
            }
        }

        public override IEnumerable<T> GetAllAdjacentVertices(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
            {
                return Enumerable.Empty<T>();
            }
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

        public IEnumerable<T> IterateDepthFirst()
        {
            var visitedTracker = new Dictionary<T, bool>(this.NumberOfVertices);
            var listOfVertex = new List<T>();

            foreach (var vertexKeyValuePair in _adjacencyList)
            {
                // 1. Start with first node
                var vertex = vertexKeyValuePair.Key;
                if (!visitedTracker.ContainsKey(vertex))
                {
                    DepthFirstTraversalRecursive(vertex);
                }
            }

            return listOfVertex;

            void DepthFirstTraversalRecursive(T vertex)
            {
                visitedTracker.Add(vertex, true);
                listOfVertex.Add(vertex);
                var adjacentVertices = GetAllAdjacentVertices(vertex);

                foreach (var adjacentVertex in adjacentVertices)
                {
                    if (!visitedTracker.ContainsKey(adjacentVertex))
                    {
                        DepthFirstTraversalRecursive(adjacentVertex);
                    }
                }
            }
        }

        public IEnumerable<T> IterateDepthFirstUsingStack()
        {
            /*
             * 	How Stack can help implement DFS?
               • Stack has property of LIFO.
               • It is used only to keep a list of nodes without the need for recursion.
               
               Algorithm
               a. Created a stack of nodes and visited array.
               b. Insert the root in the stack.
               c. Run a loop till the stack is not empty.
               d. Pop the element from the stack and print the element. 
               e. For every adjacent and unvisited node of current node, mark the node and insert it in the stack.
               
               Complexity Analysis: 
               • Time complexity: O(V + E), where V is the number of vertices and E is the number of edges in the graph.
               • Space Complexity: O(V). Since an extra visited array is needed of size V.
               
             */

            var visitedTracker = new HashSet<T>(this.NumberOfVertices);
            var stackNodes = new Stack<T>();

            foreach (var vertexKvPair in _adjacencyList)
            {
                var vertex = vertexKvPair.Key;

                if (visitedTracker.Contains(vertex))
                {
                    continue;
                }

                stackNodes.Push(vertex);

                while (stackNodes.IsNotEmpty())
                {
                    var vertexAtTop = stackNodes.Pop();
                    if (visitedTracker.Contains(vertexAtTop))
                    {
                        continue;
                    }

                    visitedTracker.Add(vertexAtTop);
                    yield return vertexAtTop;

                    var listOfNeighbors = GetAllAdjacentVertices(vertexAtTop).ToList();
                    listOfNeighbors.ForEach(x =>
                    {
                        if (!visitedTracker.Contains(x))
                        {
                            stackNodes.Push(x);
                        }
                    });
                }
            }
        }   
    }
}
