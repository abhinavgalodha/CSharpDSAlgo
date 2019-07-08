using DataStructures.Tree.Node;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DataStructures.Tree
{
    

    public class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryNode<T> RootNode {get; set;}

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

        public BinaryTree(T[] arrayOfValuesInAnyOrder)
        {
            // How to create a Binary Search Tree, Provided we have any random array which is not sorted.
            //
            
        }

        public static void Create()
        {

        }

        public T BinarySearch(T valueToSearch)
        {
            //Todo : Implement a Binary Search 
            // If less, go left; if greater, go right; if equal, search hit.
            throw new NotImplementedException();
        }

        public void Insert(T valueToAdd)
        {
            //Todo : Implement an Insert operation
            // If less, go left; if greater, go right; if null, insert.
            // throw new NotImplementedException();
            this.RootNode = InsertRecursive(this.RootNode, valueToAdd);
        }

        private BinaryNode<T> InsertRecursive(BinaryNode<T> node, T valueToAdd)
        {
            // Base condition
            if (node == null)
            {
                return new BinaryNode<T>(valueToAdd);
            }

            if (valueToAdd.IsLessThan(node.Value))
            {
                var leftNode = InsertRecursive(node.LeftNode, valueToAdd);
                node = new BinaryNode<T>(node);
            }
            else if (valueToAdd.IsGreaterThan(node.Value))
            {
                InsertRecursive(node.RightNode, valueToAdd);
            }
        }

        // TODO : Check if we need to implement the Get. Return value corresponding to given key, or null if no such key.
        //while (x != null)
        //{
        //    int cmp = key.compareTo(x.key);
        //    if (cmp < 0) x = x.left;
        //    else if (cmp > 0) x = x.right;
        //    else if (cmp == 0) return x.val;
        //}
        //return null;
    }

    }
}
