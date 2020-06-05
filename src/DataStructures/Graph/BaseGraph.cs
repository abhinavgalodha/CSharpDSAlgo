using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using DataStructures.Graph.Edge;

namespace DataStructures.Graph
{
    public abstract class BaseGraph<T> :  IGraph<T>
    {
        public abstract void AddEdge(Edge<T> edgeToAdd);

        public virtual void AddEdge(T source, T destination)
        {
            var edgeToAdd = new Edge<T>(source, destination);
            AddEdge(edgeToAdd);
        }

        public abstract IEnumerable<T> GetAllAdjacentVertices(T vertex);

        public abstract IEnumerable<T> GetAllVertices();

        public abstract IEnumerable<Edge<T>> GetAllEdges();

        public abstract bool IsCycleExists();

        public virtual int NumberOfEdges  => GetAllEdges().Count();

        public virtual int NumberOfVertices => GetAllVertices().Count();

        /// <summary>
        /// Number of vertices connected to a given vertex 
        /// </summary>
        /// <param name="vertex">Vertex for which need to find the degree</param>
        /// <returns></returns>
        public int Degree(T vertex)
        {
            vertex.ThrowIfNull(nameof(vertex));
            return GetAllAdjacentVertices(vertex).ToList().Count;
        }

        public int NumberOfSelfLoops()
        {
            // A self loop is created when Source = Destination
            return GetAllEdges().Count(x => x.IsSelfLoop());
        }

        public override string ToString()
        {
            return GetAllEdges()
                   .Aggregate( seed: string.Empty, (accumulator, initialValue) => accumulator + 
                                                                         (!string.IsNullOrWhiteSpace(accumulator)  ? " , " : string.Empty) + 
                                                                         initialValue);
        }


    }
}
