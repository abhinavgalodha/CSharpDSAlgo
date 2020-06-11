
using DataStructures.Tree.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace DataStructures.Tree
{
    public class BinaryTree<T>
    {

        public BinaryTree(T rootNodeValue)
        {
            this.RootNode = new BinaryNode<T>(rootNodeValue);
        }

        /// <summary>
        ///  Immutable version where RootNode can't be changed once created..
        /// </summary>
        public BinaryNode<T> RootNode { get; }

        /// <summary>
        /// Perform a Breadth First search in a tree.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> IterateBreadthFirst()
        {
            if (RootNode == null)
                yield return (T)Enumerable.Empty<T>();

            var queueOfNodes = new Queue<BinaryNode<T>>();

            while (queueOfNodes.Count != 0)
            {
                var currentTreeNode = queueOfNodes.Dequeue();
                yield return currentTreeNode.Value;
                
                if (currentTreeNode.LeftNode != null)
                {
                    queueOfNodes.Enqueue(currentTreeNode.LeftNode);
                }

                if (currentTreeNode.RightNode != null)
                {
                    queueOfNodes.Enqueue(currentTreeNode.RightNode);
                }
            }
            
        }

        //  TODO: BinaryNode or BinaryTree which should have methods to add/get/Delete/iterate/update
        // Search. If less, go left; if greater, go right; if equal, search hit.
        // Insert. If less, go left; if greater, go right; if null, insert.
        // Min : Min key in a tree
        // Max : Max Key in a tree
        // Floor. Largest key ≤ a given key.
        // Ceiling. Smallest key ≥ a given key.

        //public BinaryNode<T> RootNode {get;set;}

        //public BinarySearchTree(T[] arrayOfValuesInAnyOrder)
        //{
            // How to create a Binary Search Tree, Provided we have any random array which is not sorted.
            //
            
        //}

        // TODO : The Default ctor should have atleast one parameter.
        // There isn't any use of a default parameter-less ctor, what is the purpose of the a Binary Tree which doesn't have any data

        public void Insert(T valueToAdd)
        {
            // Get the Value to add
            AddLeafNodeToParentNode(valueToAdd);
            //
        }

        public void AddLeafNodeToParentNode(T valueToAdd)
        {
            // TODO: Handle the scenario if valueToAdd is equal to any existing Node.
            // Should it be added to left or right?

            BinaryNode<T> node = this.RootNode;
            BinaryNode<T> parentNode = node;
            while (node != null)
            {
                parentNode =  node;
                if (valueToAdd.IsLessThan(node.Value))
                {
                    node = node.LeftNode;
                    if (node == null)
                    {
                        parentNode.AddLeafNodeToLeft(valueToAdd);
                    }
                }
                else if (valueToAdd.IsGreaterThan(node.Value))
                {
                    node = node.RightNode;
                    if (node == null)
                    {
                        parentNode.AddLeafNodeToRight(valueToAdd);
                    }
                }
            }
        }

        

    }
}
