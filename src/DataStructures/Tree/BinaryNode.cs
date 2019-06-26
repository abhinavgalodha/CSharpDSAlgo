using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DataStructures.Tree
{
    public class BinaryNode<T> where T : IComparable<T>
    {
        

        /*
         * OBJECT CONSTRUCTION PROBLEM AND SOLUTION
         *
        Can't use a public setter, as any one can create a Left Node which is greater than parent, or right node
        Therefore, we will move the Construction logic for leftNode, Right Node into the ctor

        public BinaryNode<T> LeftNode {get;set;}

        public BinaryNode<T> RightNode {get;set;}

        public T Value { get;set;}

        */

        public BinaryNode(T value)
        {
            value.ThrowIfNull(nameof(value));

            // This is leaf node
            this.Value = value;
        }

        public BinaryNode(T value, T leftNode, T rightNode)
        {
            value.ThrowIfNull(nameof(value));
            leftNode.ThrowIfNull(nameof(leftNode));
            rightNode.ThrowIfNull(nameof(rightNode));

            //
            //  Invariants for a BST Should be met which is 
            // Left Node < Value < Right Node
            //
            if (value.IsNotInBetween(leftNode, rightNode, false))
            {
                throw new ArgumentOutOfRangeException("The inputs doesn't meet the BST property Left Node < Value < Right Node");
            }
            
            Value = value;
            //LeftNode = new Binar leftNode;
            //RightNode = rightNode;    
        }

        public BinaryNode(T value, BinaryNode<T> leftNode, BinaryNode<T> rightNode)
        {
            value.ThrowIfNull(nameof(value));
            leftNode.ThrowIfNull(nameof(leftNode));
            rightNode.ThrowIfNull(nameof(rightNode));

            //
            //  Invariants for a BST Should be met which is 
            // Left Node < Value < Right Node
            //
            if (value.IsNotInBetween(leftNode.Value, rightNode.Value, false))
            {
                throw new ArgumentOutOfRangeException("The inputs doesn't meet the BST property Left Node < Value < Right Node");
            }
            
            Value = value;
            LeftNode = leftNode;
            RightNode = rightNode;    
        }

        // TODO: Add a operator to simplify the comparison or working on LeftNode.Value with value. operator overloading..

        public BinaryNode<T> LeftNode {get;}

        public BinaryNode<T> RightNode {get;}

        public T Value { get;}

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
