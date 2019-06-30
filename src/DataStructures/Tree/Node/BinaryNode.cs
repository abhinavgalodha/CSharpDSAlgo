using System;
using System.Collections.Generic;
using Core;

namespace DataStructures.Tree.Node
{
    public class BinaryNode<T> : LeafNode<T> where T : IComparable<T>
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

        public BinaryNode(T value) : base(value)
        {
        }

        public BinaryNode(T value, T leftNode, T rightNode) : this(value)
        {
            value.ThrowIfNull(nameof(value));
            leftNode.ThrowIfNull(nameof(leftNode));
            rightNode.ThrowIfNull(nameof(rightNode));

            var leftBinaryNode = new BinaryNode<T>(leftNode);
            var rightBinaryNode = new BinaryNode<T>(leftNode);

            this.LeftNode = leftBinaryNode;
            this.RightNode = rightBinaryNode;
        }

        public BinaryNode(T value, BinaryNode<T> leftNode, BinaryNode<T> rightNode) : this(value)
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
            
            this.LeftNode = leftNode;
            this.RightNode = rightNode;    
        }

        //public BinaryNode(params T[] values) : this(values[0]) 
        //{
        //    for (int index = 1; index < values.Length; index++)
        //    {
        //        var currentNode = new BinaryNode<T>(values[index]);

        //        if (currentNode.IsLessThan(this))
        //        {
        //            this.LeftNode
        //        }

        //        //ifthis.Value
        //    }
        //}

        public static BinaryNode<T> CreateABinaryNode(params T[] values)
        {
            if (values.Length == 0)
            {
                throw new ArgumentNullException("The Input doesn't contain any elements to create a Binary node");
            }

            // First element is taken as the Root Element
            var rootNode = new BinaryNode<T>(values[0]);

            // Since the root node is already consumed, the counter starts at 1.
            for (int index = 1; index < values.Length; index++)
            {
                var currentValue = values[index];
                BinaryNode<T> currentNode = new BinaryNode<T>(currentValue);
                if (currentNode.Value.IsLessThan(rootNode.Value))
                {
                    rootNode.LeftNode = currentNode;
                }
                else
                {
                    rootNode.RightNode = currentNode;
                }
            }

            return rootNode;
        }

        // TODO: Add a operator to simplify the comparison or working on LeftNode.Value with value. operator overloading..
        public BinaryNode<T>? LeftNode {get; private set;}

        public BinaryNode<T>? RightNode {get; private set;}

        /// <summary>
        /// Is it the terminating leaf node or not?
        /// If a node doesn't have Left or right Node, then it is a Leaf Node..
        /// </summary>
        public bool IsLeafNode => this.LeftNode == null && this.RightNode == null;

        public bool IsAParentNode => !this.IsLeafNode;

        //
        // Following property uses C# 8.0 Null reference on BinaryNode<T>? LeftNode
        // Since we have designated that the left node, right node can be null
        // If we remove the check this.LeftNode != null then the analyzer would warn of
        // a possible null value dereference.
        //
        public bool IsAParentOfALeafNode => this.IsAParentNode &&
                                            this.LeftNode != null &&
                                            this.LeftNode.IsLeafNode &&
                                            this.RightNode != null &&
                                            this.RightNode.IsLeafNode;

        public IEnumerable<T> TraverseInOrder()
        {
            List<T> listInOrderAfterTraversal = new List<T>();
            TraverseInOrder(this, listInOrderAfterTraversal);
            return listInOrderAfterTraversal;
        }

        public static IEnumerable<T> TraverseInOrder(BinaryNode<T> nodeToTraverse)
        {
            nodeToTraverse.ThrowIfNull(nameof(nodeToTraverse));
            return nodeToTraverse.TraverseInOrder();
        }

        private void TraverseInOrder(BinaryNode<T> nodeToTraverse, IList<T> listInOrderAfterTraversal)
        {
            // Base condition
            if (nodeToTraverse == null || nodeToTraverse.IsLeafNode)
            {
                return;
            }

            var test = this.LeftNode?.IsLeafNode;

            if (listInOrderAfterTraversal == null)
            {
                listInOrderAfterTraversal = new List<T>();
            }

            TraverseInOrder(this.LeftNode, listInOrderAfterTraversal);
            if (this.IsLeafNode)
            {
                return;
            }

            // C# 8, Possible Null Dereference suggested by analyzer, therefore checking..
            if (this.LeftNode != null)
            {
                listInOrderAfterTraversal.Add(this.LeftNode.Value);    
            }

            
            listInOrderAfterTraversal.Add(this.Value);

            TraverseInOrder(this.RightNode, listInOrderAfterTraversal);

            // C# 8, Possible Null Dereference suggested by analyzer, therefore checking..
            if (this.RightNode != null)
            {
                listInOrderAfterTraversal.Add(this.RightNode.Value);    
            }
            
            
        }

    }
}
