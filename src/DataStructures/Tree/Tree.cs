using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Tree
{
    /// <summary>
    /// A Class to represent the Tree Data Structure
    /// </summary>
    public class Tree<T>
    {
        public Node<T> RootNode { get; set; }

        public Tree(Node<T> rootNode)
        {
            this.RootNode = RootNode ?? throw new ArgumentNullException("Root node shouldn't be null");
        }

        


    }

    public class Node<T>
    {
        public IEnumerable<T> Child {get; set;}

        public T Value { get; set;}

    }

}
