using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using DataStructures.Graph.Edge;

namespace DataStructures.Graph.Implementation
{
    public class GraphUsingArray<T> : BaseGraph<T>
    {
        private readonly List<Edge<T>> _listOfEdges;

        public GraphUsingArray()
        {
            _listOfEdges = new List<Edge<T>>();
        }

        public override void AddEdge(Edge<T> edgeToAdd)
        {
            edgeToAdd.ThrowIfNull(nameof(edgeToAdd));

            _listOfEdges.Add(edgeToAdd);
        }

        public override void AddEdge(T source, T destination)
        {
            var edgeToAdd = new Edge<T>(source, destination);
            AddEdge(edgeToAdd);
        }

        public override IEnumerable<T> GetAllAdjacentVertices(T vertex)
        {
            return _listOfEdges.Where(x => x.From.Equals(vertex))
                .Select(x => x.To);
        }

        public override IEnumerable<T> GetAllVertices()
        {
            IEnumerable<T> sourceVertices = _listOfEdges.Select(x => x.From);
            IEnumerable<T> destinationVertices = _listOfEdges.Select(x => x.To);
            IEnumerable<T> uniqueVerticesInGraph = sourceVertices.Union(destinationVertices).Distinct();
            return uniqueVerticesInGraph;
        }

        public override IEnumerable<Edge<T>> GetAllEdges()
        {
            return _listOfEdges;
        }

        public override bool IsCycleExists()
        {
            throw new NotImplementedException();
        }

        
    }
}
