using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using DataStructures.Graph.Edge;

namespace DataStructures.Graph.Implementation
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
            return m_listOfEdges.Where(x => x.From.Equals(vertex))
                .Select(x => x.To);
        }

        public override IEnumerable<T> GetAllVertices()
        {
            IEnumerable<T> sourceVertices = m_listOfEdges.Select(x => x.From);
            IEnumerable<T> destinationVertices = m_listOfEdges.Select(x => x.To);
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

        
    }
}
