using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using DataStructures.Graph.Edge;

namespace DataStructures.Graph.Implementation
{
    public class GraphUsingAdjMatrix<T> : BaseGraph<T>
    {
        private readonly Dictionary<T, int> _dictVertexAndIndex;
        private readonly List<List<bool>> _adjacencyMatrix;

        public GraphUsingAdjMatrix()
        {
            _dictVertexAndIndex = new Dictionary<T, int>();
            _adjacencyMatrix = new List<List<bool>>();
        }

        public override void AddEdge(Edge<T> edgeToAdd)
        {
            edgeToAdd.ThrowIfNull(nameof(edgeToAdd));
            
            int fromVertex = GetIndexOfVertexInGraph(edgeToAdd.From);
            int toVertex = GetIndexOfVertexInGraph(edgeToAdd.To);

            _adjacencyMatrix[fromVertex][toVertex] = true;
            _adjacencyMatrix[toVertex][fromVertex] = true;

            int GetIndexOfVertexInGraph(T vertex)
            {
                if (IsVertexInGraph(vertex))
                {
                    return GetVertexIndexInGraph(vertex);
                }
                return AddAndReturnTheIndexOfNewVertex(vertex);
            }

            int AddAndReturnTheIndexOfNewVertex(T edgeToAdd)
            {
                int maxCurrentIndexValue = _dictVertexAndIndex.Max(x => x.Value);
                _dictVertexAndIndex.Add(edgeToAdd, maxCurrentIndexValue);
                return maxCurrentIndexValue;
            }

            int GetVertexIndexInGraph(T vertexToFind)
            {
                if (IsVertexInGraph(vertexToFind))
                {
                    return _dictVertexAndIndex[vertexToFind];
                }

                return -1;
            }

            bool IsVertexInGraph(T vertexToFind)
            {
                return _dictVertexAndIndex.ContainsKey(vertexToFind);
            }
        }

        public override IEnumerable<T> GetAllAdjacentVertices(T vertex)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Edge<T>> GetAllEdges()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> GetAllVertices()
        {
            throw new NotImplementedException();
        }

        public override bool IsCycleExists()
        {
            throw new NotImplementedException();
        }
    }
}
