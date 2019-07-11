using DataStructures.Tree.Node;
using System;
using Core;

namespace DataStructures.Tree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {

        public BinarySearchTree(T rootNodeValue)
        {
            this.RootNode = new BinaryNode<T>(rootNodeValue);
        }

        /// <summary>
        ///  Immutable version where RootNode can't be changed once created..
        /// </summary>
        public BinaryNode<T> RootNode {get;}

        // As per coursera princeton course
        //  TODO: Java definition. A BST is a reference to a root Node.

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

        public static void Create()
        {

        }

        public BinaryNode<T>? BinarySearch(T valueToSearch)
        {
            //Todo : Implement a Binary Search 
            // If less, go left; if greater, go right; if equal, search hit.
            
            //
            //while (x != null)
            //{
            //    int cmp = key.compareTo(x.key);
            //    if (cmp < 0) x = x.left;
            //    else if (cmp > 0) x = x.right;
            //    else if (cmp == 0) return x.val;
            //}

            valueToSearch.ThrowIfNull(nameof(valueToSearch));
             
            BinaryNode<T> node = this.RootNode;

            while (node != null)
            {
                // TODO: Needs to implement the Equality operator and implement interface IEquitable
                if(node.Value.Equals(valueToSearch))
                {
                    return node;
                }
                else if(valueToSearch.IsLessThan(node.Value))
                {
                    node = node.LeftNode;
                }
                else
                {
                    node = node.RightNode;
                }
            }
            return null;
        }


        // TODO: Implement following
        // Size - In each node, we store the number of nodes in the subtree rooted at that node;
        //        to implement size(), return the count at the root.
        // Rank -  How many keys < k
        //

        public void Insert(T valueToAdd)
        {
            //Todo : Implement an Insert operation
            // If less, go left; if greater, go right; if null, insert.
            InsertRecursive(this.RootNode, valueToAdd);
        }
        public void InsertV1(T valueToAdd)
        {
            // Get the Value to add
            var parentNode = GetParentNodeToInsert(valueToAdd);
            //
        }

        private BinaryNode<T> InsertRecursive(BinaryNode<T> node, T valueToAdd)
        {
            //Base condition
            if (node == null)
            {
                return new BinaryNode<T>(valueToAdd);
            }

            if (valueToAdd.IsLessThan(node.Value))
            {
                var leftNode = InsertRecursive(node.LeftNode, valueToAdd);
                node.AddLeafNodeToLeft(leftNode);
            }
            else if (valueToAdd.IsGreaterThan(node.Value))
            {
                var rightNode = InsertRecursive(node.RightNode, valueToAdd);
                node.AddLeafNodeToRight(rightNode);
            }

            return node;
        }


        private BinaryNode<T> GetParentNodeToInsert(T valueToAdd)
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
                    
                }
                else if (valueToAdd.IsGreaterThan(node.Value))
                {
                    node = node.RightNode;
                }   
            }

            return parentNode;
        }

        /// <summary>
        /// Gets the minimum element in the tree
        /// The leftmost element is the minimum element
        /// </summary>
        /// <returns></returns>
        public T Minimum()
        {
            BinaryNode<T> binaryNode = this.RootNode;
            while (binaryNode.HasLeftNode)
            {
                binaryNode = binaryNode.LeftNode;
            }

            return binaryNode.Value;
        }

        /// <summary>
        /// Gets the minimum element in the tree
        /// The leftmost element is the minimum element
        /// </summary>
        /// <returns></returns>
        public T Maximum()
        {
            BinaryNode<T> binaryNode = this.RootNode;
            while (binaryNode.HasRightNode)
            {
                binaryNode = binaryNode.RightNode;
            }

            return binaryNode.Value;
        }


    }
}
