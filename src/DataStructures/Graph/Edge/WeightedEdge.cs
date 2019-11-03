using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DataStructures.Graph
{
    public class WeightedEdge<T> : Edge<T>
    {
        public int Weight { get;}

        public WeightedEdge(T source, T destination, int weight) : base(source, destination)
        {
            if (weight < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Weight Shouldn't be negative in a weighted Edge.");
            }

            Weight = weight;

        }

    }
}
