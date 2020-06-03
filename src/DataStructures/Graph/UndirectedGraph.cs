using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Graph.Edge;

namespace DataStructures.Graph
{
    public abstract class UndirectedGraph<T> : BaseGraph<T>
    {
        public abstract override void AddEdge(Edge<T> edgeToAdd);

        public abstract override void AddEdge(T source, T destination);

        public abstract override IEnumerable<T> GetAllAdjacentVertices(T vertex);

        public abstract override IEnumerable<T> GetAllVertices();

        public abstract override IEnumerable<Edge<T>> GetAllEdges();

        public abstract override bool IsCycleExists();

        public abstract override int NumberOfEdges { get; }

        public abstract override int NumberOfVertices { get; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
