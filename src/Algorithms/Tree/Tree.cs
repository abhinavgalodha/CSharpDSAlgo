using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Tree
{
    public class Tree
    {
    }

    public class Node<T>
    {
        public IEnumerable<T> AdjacentNodes {get; set;}

        public T Value { get; set;}

    }
}
