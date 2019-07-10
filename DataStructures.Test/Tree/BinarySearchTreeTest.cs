﻿using DataStructures.Tree;
using FluentAssertions;
using Xunit;

namespace DataStructures.Test.Tree
{
    public class BinaryTreeTest
    {
        [Fact]
        public void Should_InsertNode_AtTheRoot_InTheBinaryTree()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            // Arrange
            bst.Insert(5);

            // Assert
            bst.RootNode.Value.Should().Be(5);
        }

        [Fact]
        public void Should_InsertLeftNode_InTheBinaryTree()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            // Arrange
            bst.Insert(5);

            // Insert left node
            bst.Insert(4);
            

            // Assert
            bst.RootNode.LeftNode.Value.Should().Be(4);
        }


        [Fact]
        public void Should_InsertRightNode_InTheBinaryTree()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            // Arrange
            bst.Insert(5);

            // Insert left node
            bst.Insert(10);
            

            // Assert
            bst.RootNode.RightNode.Value.Should().Be(10);
        }
    }
}
