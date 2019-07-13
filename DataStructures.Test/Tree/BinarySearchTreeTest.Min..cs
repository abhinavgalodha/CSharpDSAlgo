using DataStructures.Tree;
using FluentAssertions;
using Xunit;

namespace DataStructures.Test.Tree
{
    [Trait("Category", "BST")]
    [Trait("Category", "Min")]
    public partial class BinaryTreeTest
    {
        [Fact]
        public void Should_ReturnMinAsRoot_WhenOnlyElementIsRoot()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>(5);

            // Assert
            bst.Minimum().Should().Be(5);
        }

        [Fact]
        public void Should_ReturnMinAsLeftMost_WhenLeftSubTreeIsPresent()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>(5);

            // Arrange
            bst.Insert(4);
            bst.Insert(6);

            // Assert
            bst.Minimum().Should().Be(4);
        }

        [Fact]
        public void Should_ReturnMinAsRoot_WhenOnlyRightSubTreeIsPresent()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>(5);

            // Arrange
            bst.Insert(6);
            bst.Insert(7);
            bst.Insert(8);
            bst.Insert(9);

            // Assert
            bst.Minimum().Should().Be(5);
        }

        [Fact]
        public void Should_ReturnMinAsLeftmost_WhenLeftSubTreeIsBig()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>(10);

            // Arrange
            bst.Insert(6);
            bst.Insert(20);
            bst.Insert(5);
            bst.Insert(8);
            bst.Insert(1);

            // Assert
            bst.Minimum().Should().Be(1);
        }

    }
}

