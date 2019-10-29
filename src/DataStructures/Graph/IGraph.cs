using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graph
{
    public interface IGraph<T>
    {
        /// <summary>
        /// Adds and edge from source to destination
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        void AddEdge(T source, T destination);

        IEnumerable<T> GetAllAdjacentVertices(T vertex);

        int NumberOfEdges { get; }

        int NumberOVertices { get; }


    }
}

