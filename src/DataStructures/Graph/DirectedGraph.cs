using DataStructures.Graph.Edge;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graph
{
    public abstract class DirectedGraph<T> : BaseGraph<T>
    {
        public abstract override void AddEdge(Edge<T> edgeToAdd);

        public abstract override void AddEdge(T @from, T to);

        public abstract override IEnumerable<T> GetAllAdjacentVertices(T vertex);

        public abstract override IEnumerable<T> GetAllVertices();

        public abstract override IEnumerable<Edge<T>> GetAllEdges();

        public abstract override bool IsCycleExists();

        public abstract override int NumberOfEdges { get; }

        public abstract override int NumberOfVertices { get; }

        

    }
}
