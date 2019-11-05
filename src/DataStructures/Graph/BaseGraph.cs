using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace DataStructures.Graph
{
    public abstract class BaseGraph<T> :  IGraph<T>
    {
        public abstract void AddEdge(Edge<T> edgeToAdd);

        public abstract void AddEdge(T source, T destination);

        public abstract IEnumerable<T> GetAllAdjacentVertices(T vertex);

        public abstract virtual IEnumerable<T> GetAllVertices();

        public abstract IEnumerable<Edge<T>> GetAllEdges();

        public abstract bool IsCycleExists();

        public abstract int NumberOfEdges { get; }

        public abstract int NumberOfVertices { get; }

        // Number of vertices connected to a given vertex
        public int Degree(T vertex)
        {
            vertex.ThrowIfNull(nameof(vertex));
            return GetAllAdjacentVertices(vertex).ToList().Count;
        }
    }
}
