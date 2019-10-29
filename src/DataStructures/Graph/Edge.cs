using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DataStructures.Graph
{
    public class Edge<T>
    {
        public Edge(T source, T destination)
        {
            source.ThrowIfNull(nameof(source));
            source.ThrowIfNull(nameof(destination));

            Source = source;
            Destination = destination;
        }

        public T Source { get;}

        public T Destination { get;}

    }
}
