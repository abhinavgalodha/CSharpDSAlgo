﻿using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DataStructures.Graph
{
    public class DirectedEdge<T> : Edge<T>
    {
        public DirectedEdge(T source, T destination) : base(source, destination)
        {
        }


    }
}
