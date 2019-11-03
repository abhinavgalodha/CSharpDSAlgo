using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core;
using System.Linq;

namespace DataStructures.Graph
{
    public class GraphUsingArray<T> : BaseGraph<T>
    {
        private readonly List<Edge<T>> m_listOfEdges;

        public GraphUsingArray()
        {
            m_listOfEdges = new List<Edge<T>>();
        }

        public override void AddEdge(Edge<T> edgeToAdd)
        {
            edgeToAdd.ThrowIfNull(nameof(edgeToAdd));

            m_listOfEdges.Add(edgeToAdd);
        }

        public override void AddEdge(T source, T destination)
        {
            var edgeToAdd = new Edge<T>(source, destination);
            AddEdge(edgeToAdd);
        }

        public override IEnumerable<T> GetAllAdjacentVertices(T vertex)
        {
            return m_listOfEdges.Where(x => x.Source.Equals(vertex))
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

        public override int NumberOfVertices => GetAllVertices().Count();

        public override int NumberOfEdges => m_listOfEdges.Count;
    }
}
