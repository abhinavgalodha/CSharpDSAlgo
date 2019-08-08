using System;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using DataStructures.Tree.Enum;

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


        private LeftNode<T> m_LeftNode1;
        private RightNode<T> m_RightNode1;

        // TODO: Should LeftNode and RightNode be seperate classes with a relationship?

        private BinaryNode<T> m_LeftNode;
        private BinaryNode<T> m_RightNode;

        // TODO: Add a operator to simplify the comparison or working on LeftNode.Value with value. operator overloading..
        public BinaryNode<T>? LeftNode
        {
            get => m_LeftNode;
            private set
            {
                value.ThrowIfNull("LeftNode");

                if (!IsBSTInvariantMet(this, value.Value, BinaryNodePosition.Left))
                {
                    throw new ArgumentException("The value of the left node has to be less than of the Parent Node");
                };

                m_LeftNode = value;
            }
        }

        public BinaryNode<T>? RightNode
        {
            get => m_RightNode;
            private set
            {
                value.ThrowIfNull("RightNode");

                if (!IsBSTInvariantMet(this, value.Value, BinaryNodePosition.Right))
                {
                    throw new ArgumentException("The value of the Right node must be greater than the Parent Node");
                };

                m_RightNode = value;
            }
        }


        /// <summary>
        /// Is it the terminating leaf node or not?
        /// If a node doesn't have Left or right Node, then it is a Leaf Node..
        /// </summary>
        public bool IsLeafNode => this.LeftNode == null && this.RightNode == null;

        public bool IsAParentNode => !this.IsLeafNode;

        public bool HasLeftNode => this.LeftNode != null;

        public bool HasRightNode => this.RightNode != null;

        //
        // Following property uses C# 8.0 Null reference on BinaryNode<T>? LeftNode
        // Since we have designated that the left node, right node can be null
        // If we remove the check this.LeftNode != null then the analyzer would warn of
        // a possible null value dereference.
        //
        // Update: There has been new property added HasLeftNode, HasRightNode to handle the leftNode and RightNode null scenarios
        //
        public bool IsAParentOfALeafNode => this.IsAParentNode &&
                                            (this.HasLeftNode &&
                                            this.LeftNode.IsLeafNode) ||
                                            (this.HasRightNode &&
                                            this.RightNode.IsLeafNode);


        private Func<BinaryNode<T>, T, BinaryNodePosition, bool> IsBSTInvariantMet = (node, valueToAdd, nodePosition) =>
        {
             if (nodePosition == BinaryNodePosition.Left)
             {
                 return valueToAdd.IsLessThanEqualTo(node.Value);
             }
             return valueToAdd.IsGreaterThan(node.Value);
        };

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


        // TODO : DO we need a constructor with Params ?
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
            BinaryNode<T> currentNode = rootNode;

            // Since the root node is already consumed, the counter starts at 1.
            for (int index = 1; index < values.Length; index++)
            {
                var currentValue = values[index];
                (BinaryNode<T> binaryNodeWhereTheValueCanBeAdded, BinaryNodePosition nodePosition) = GetBinaryNodeToAppendTheValue(currentNode, currentValue);
                switch (nodePosition)
                {
                    case BinaryNodePosition.Left:
                        binaryNodeWhereTheValueCanBeAdded.LeftNode = new BinaryNode<T>(currentValue);
                        break;

                    case BinaryNodePosition.Right:
                        binaryNodeWhereTheValueCanBeAdded.RightNode = new BinaryNode<T>(currentValue);
                        break;
                }
            }

            return rootNode;
        }

        public void AddLeafNodeToLeft(BinaryNode<T> nodeToAdd)
        {
            // Validation : Null Gaurd
            nodeToAdd.ThrowIfNull(nameof(nodeToAdd));

            // Validation : If LeftNode already exists, it can't be added again
            if (this.HasLeftNode)
            {
                throw new InvalidOperationException("The Node already has the left node. An Add operation can't update existing Node value.");
            }

            this.LeftNode = nodeToAdd;
        }

        public void AddLeafNodeToLeft(T valueToAdd)
        {
            // Validation : Null Gaurd
            valueToAdd.ThrowIfNull(nameof(valueToAdd));
            this.AddLeafNodeToLeft(new BinaryNode<T>(valueToAdd));
        }

        public void AddLeafNodeToRight(BinaryNode<T> nodeToAdd)
        {
            // Validation : Null Gaurd
            nodeToAdd.ThrowIfNull(nameof(nodeToAdd));

            // Validation : If LeftNode already exists, it can't be added again
            if (this.HasRightNode)
            {
                throw new InvalidOperationException("The Node already has the Right node. An Add operation can't update existing Node value.");
            }

            this.RightNode = nodeToAdd;
        }

        /// <summary>
        /// Adds a value to the Right of the Existing Binary Node
        /// </summary>
        /// <param name="valueToAdd"></param>
        public void AddLeafNodeToRight(T valueToAdd)
        {
            valueToAdd.ThrowIfNull(nameof(valueToAdd));
            this.AddLeafNodeToRight(new BinaryNode<T>(valueToAdd));
        }

        private static (BinaryNode<T>, BinaryNodePosition) GetBinaryNodeToAppendTheValue(BinaryNode<T> binaryNode, T newValueToAdd)
        {
            BinaryNode<T> newBinaryNodeToAdd = new BinaryNode<T>(newValueToAdd);
            if (binaryNode.IsLeafNode)
            {
                // If leaf node is the only node, then add to left or right depending if the element is less or greater than the Root value
                if (newBinaryNodeToAdd.Value.IsLessThan(binaryNode.Value))
                {
                    // Usage of C# 7.0 Tuples
                    return (binaryNode, BinaryNodePosition.Left);
                }

                return (binaryNode, BinaryNodePosition.Right);
            }

            // If you have reached here, then the node is not the leaf node and it needs further exploration
            if (newBinaryNodeToAdd.Value.IsLessThan(binaryNode.Value))
            {
                //
                // Go Left in tree 
                //
                if (!binaryNode.HasLeftNode)
                {
                    return (binaryNode, BinaryNodePosition.Left);
                }
                return GetBinaryNodeToAppendTheValue(binaryNode.LeftNode, newBinaryNodeToAdd.Value);
            }
            else
            {
                // Go Right
                if (!binaryNode.HasRightNode)
                {
                    return (binaryNode, BinaryNodePosition.Right);
                }
                return GetBinaryNodeToAppendTheValue(binaryNode.RightNode, newBinaryNodeToAdd.Value);
            }

        }

        public IEnumerable<T> TraverseInOrder()
        {
            return BinaryNode<T>.TraverseInOrder(this);
        }

        public static IEnumerable<T> TraverseInOrder(BinaryNode<T> nodeToTraverse)
        {
            nodeToTraverse.ThrowIfNull(nameof(nodeToTraverse));
            IList<T> listInOrderAfterTraversal = new List<T>();
            TraverseInOrder(nodeToTraverse, listInOrderAfterTraversal);
            return listInOrderAfterTraversal;
        }

        private static void TraverseInOrder(BinaryNode<T> nodeToTraverse, IList<T> listInOrderAfterTraversal)
        {
            // In Order traversal
            // Node Left -> Node Value -> Node Right

            // Start from Root
            // Step 1: Keep Going Left
            //         If Node is last node/leaf node, then Add it to the list
            //         Next Add Parent
            //  Keep Going Left and follow as on Step 1

            // Base condition
            if (nodeToTraverse == null)
            {
                return;
            }
            if (nodeToTraverse.IsLeafNode)
            {
                if (listInOrderAfterTraversal == null)
                {
                    listInOrderAfterTraversal = new List<T>();
                }
                listInOrderAfterTraversal.Add(nodeToTraverse.Value);
                return;
            }

            // TODO : Handle the case of only 1 element in the Node


            TraverseInOrder(nodeToTraverse.LeftNode, listInOrderAfterTraversal);

            listInOrderAfterTraversal.Add(nodeToTraverse.Value);

            TraverseInOrder(nodeToTraverse.RightNode, listInOrderAfterTraversal);

        }
    }
}

