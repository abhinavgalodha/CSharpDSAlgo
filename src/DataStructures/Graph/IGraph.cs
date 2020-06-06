using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.Graph.Edge;

namespace DataStructures.Graph
{
    public interface IGraph<T>
    {
        /// <summary>
        /// Adds and edge from source to destination
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        void AddEdge(T @from, T to);

        IEnumerable<T> GetAllAdjacentVertices(T vertex);

        IEnumerable<T> GetAllVertices();

        IEnumerable<Edge<T>> GetAllEdges();

        bool IsCycleExists(); 

        int NumberOfEdges { get; }

        int NumberOfVertices { get; }

        int Degree(T vertex);


    }
}

