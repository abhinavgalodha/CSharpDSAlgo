using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DataStructures.Graph
{
    public class Edge<T>
    {
        public Edge(T from, T to)
        {
            from.ThrowIfNull(nameof(@from));
            from.ThrowIfNull(nameof(to));

            From = from;
            To = to;
        }

        public T From { get;}

        public T To { get;}

        public bool IsSelfLoop()
        {
            return EqualityComparer<T>.Default.Equals(From, To);
        }

        public Edge<T> ReverseEdge()
        {
            return new Edge<T>(To, From);
        }

        public override string ToString()
        {
            return From.ToString() + "->" + To.ToString();
        }

    }
}
