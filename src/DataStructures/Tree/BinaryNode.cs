using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Tree
{
    public class BinaryNode<T>
    {
        public BinaryNode<T> LeftNode {get;set;}

        public BinaryNode<T> RightNode {get;set;}

        public T Value { get;set;}

        /// <summary>
        /// Is it the terminating leaf node or not?
        /// If a node doesn't have Left or right Node, then it is a Leaf Node..
        /// </summary>
        public bool IsLeafNode => this.LeftNode == null && this.RightNode == null;

        public bool IsAParentNode => !this.IsLeafNode;

        public bool IsAParentOfALeafNode => this.IsAParentNode &&
                                            this.LeftNode.IsLeafNode &&
                                            this.RightNode.IsLeafNode;



        public void InOrderTraverse(BinaryNode<T> nodeToTraverse, IList<T> listInOrderAfterTraversal)
        {
            // Base condition
            if (nodeToTraverse.IsLeafNode)
            {
                return;
            }

            if (listInOrderAfterTraversal == null)
            {
                listInOrderAfterTraversal = new List<T>();
            }

            InOrderTraverse(this.LeftNode, listInOrderAfterTraversal);
            if (this.IsLeafNode)
            {
                return;
            }

            listInOrderAfterTraversal.Add(this.LeftNode.Value);
            listInOrderAfterTraversal.Add(this.Value);

            InOrderTraverse(this.RightNode, listInOrderAfterTraversal);
            listInOrderAfterTraversal.Add(this.RightNode.Value);
            
        }

    }
}
