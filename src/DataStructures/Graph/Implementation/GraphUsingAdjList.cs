using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core;
using System.Linq;

namespace DataStructures.Graph
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

            var vertexFrom = edgeToAdd.From;
            var vertexTo = edgeToAdd.To;

            if (_adjacencyList.ContainsKey(vertexFrom))
            {
                _adjacencyList[vertexFrom].Add(vertexTo);
                return;
            }

            List<T> listOfVerticesFromVertex = new List<T> {vertexTo};
            _adjacencyList.Add(vertexFrom, listOfVerticesFromVertex);

        }

        public void AddEdge1(Edge<T> edgeToAdd)
        {
            edgeToAdd.ThrowIfNull(nameof(edgeToAdd));

            if (vertexFrom)
            {
                
            }

            AddNewVertexInAdjacencyDictAndAddToVertexInList(_adjacencyList, edgeToAdd);

            AppendToVertexInExistingVertexInAdjacencyList(_adjacencyList, edgeToAdd);
        }

        private void AppendToVertexInExistingVertexInAdjacencyList(Dictionary<T, List<T>> adjacencyList, Edge<T> edgeToAdd)
        {
            var vertexFrom = edgeToAdd.From;
            var vertexTo = edgeToAdd.To;

            List<T> listOfVerticesFromVertex = new List<T> {vertexTo};
            _adjacencyList.Add(vertexFrom, listOfVerticesFromVertex);

        }

        private void AddNewVertexInAdjacencyDictAndAddToVertexInList(Dictionary<T, List<T>> adjacencyList, Edge<T> edgeToAdd)
        {
            var vertexFrom = edgeToAdd.From;
            var vertexTo = edgeToAdd.To;

            if (_adjacencyList.ContainsKey(vertexFrom))
            {
                _adjacencyList[vertexFrom].Add(vertexTo);
            }
        }


        public override void AddEdge(T source, T destination)
        {
            var edgeToAdd = new Edge<T>(source, destination);
            AddEdge(edgeToAdd);
        }

        public override IEnumerable<T> GetAllAdjacentVertices(T vertex)
        {
            return GetAllAdjacentVertices().Where(x => x.Source.Equals(vertex))
                .Select(x => x.Destination);
        }

        public override IEnumerable<T> GetAllVertices()
        {
            IEnumerable<T> sourceVertices = m_listOfEdges.Select(x => x.Source);
            IEnumerable<T> destinationVertices = m_listOfEdges.Select(x => x.Destination);
            IEnumerable<T> uniqueVerticesInGraph = sourceVertices.Union(destinationVertices).Distinct();
            return uniqueVerticesInGraph;
        }

        public override IEnumerable<Edge<T>> GetAllEdges()
        {
            return m_listOfEdges;
        }

        public override bool IsCycleExists()
        {
            throw new NotImplementedException();
        }

        public override int NumberOfVertices => GetAllVertices().Count();

        public override int NumberOfEdges => m_listOfEdges.Count;
    }
}
