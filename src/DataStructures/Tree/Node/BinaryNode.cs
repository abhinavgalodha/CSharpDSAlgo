﻿using System;
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

        public BinaryNode(params T[] values) : this(values[0]) 
        {
            for (int index = 1; index < values.Length; index++)
            {
                var currentNode = new BinaryNode<T>(values[index]);

                if (currentNode.Value < this.Value)
                {
                    
                }

                //ifthis.Value
            }
        }

        // TODO: Add a operator to simplify the comparison or working on LeftNode.Value with value. operator overloading..
        public BinaryNode<T>? LeftNode {get;}

        public BinaryNode<T>? RightNode {get;}

        /// <summary>
        /// Is it the terminating leaf node or not?
        /// If a node doesn't have Left or right Node, then it is a Leaf Node..
        /// </summary>
        public bool IsLeafNode => this.LeftNode == null && this.RightNode == null;

        public bool IsAParentNode => !this.IsLeafNode;

        public bool IsAParentOfALeafNode => this.IsAParentNode &&
                                            this.LeftNode.IsLeafNode &&
                                            this.RightNode.IsLeafNode;

        public static explicit operator T

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
