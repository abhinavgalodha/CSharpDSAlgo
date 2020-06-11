using DataStructures.Tree;
using DataStructures.Tree.Node;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace DataStructures.Test.Tree.BinaryTree
{
    [Trait("Category", "Tree")]
    public class BinaryTreeTests
    {
        [Fact]
        public void Should_InsertNode_AtTheRoot_InTheBinaryTree()
        {
            // Arrange
            var rootNode = new BinaryNode<int>(8);

            rootNode.LeftNode = new BinaryNode<int>(7);
            rootNode.LeftNode.LeftNode = new BinaryNode<int>(6);
            rootNode.LeftNode.RightNode = new BinaryNode<int>(5);
            
            rootNode.RightNode = new BinaryNode<int>(1);
            rootNode.RightNode.LeftNode = new BinaryNode<int>(2);
            rootNode.RightNode.RightNode = new BinaryNode<int>(3);
            rootNode.RightNode.RightNode.RightNode = new BinaryNode<int>(4);
            var binaryTree = new BinaryTree<int>(rootNode);
            
            // Act
            var breadthFirstTraversal = binaryTree.TraversalBreadthFirst().ToList();

            // Assert
            var expectedResult = new List<int> { 8,7,1, 6, 5 ,2,3,4 };
            breadthFirstTraversal.Should().BeEquivalentTo(expectedResult, options => options.WithStrictOrdering());
        }
    }
}
