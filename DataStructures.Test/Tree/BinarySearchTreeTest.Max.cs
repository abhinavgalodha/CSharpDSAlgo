using DataStructures.Tree;
using FluentAssertions;
using Xunit;

namespace DataStructures.Test.Tree
{
    [Trait("Category", "BST")]
    [Trait("Category", "Max")]
    public partial class BinaryTreeTest
    {
        [Fact]
        public void Should_ReturnMaxAsRoot_WhenOnlyElementIsRoot()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>(5);

            // Assert
            bst.Maximum().Should().Be(5);
        }

        [Fact]
        public void Should_ReturnMaxAsRightMost_WhenRightSubTreeIsPresent()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>(5);

            // Arrange
            bst.Insert(4);
            bst.Insert(6);

            // Assert
            bst.Maximum().Should().Be(6);
        }

        [Fact]
        public void Should_ReturnMaxAsRoot_WhenOnlyLeftSubTreeIsPresent()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>(5);

            // Arrange
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(1);

            // Assert
            bst.Maximum().Should().Be(5);
        }

        [Fact]
        public void Should_ReturnMaxAsRightMost_WhenRightSubTreeIsBig()
        {
            // Act
            BinarySearchTree<int> bst = new BinarySearchTree<int>(10);

            // Arrange
            bst.Insert(6);
            bst.Insert(20);
            bst.Insert(5);
            bst.Insert(80);
            bst.Insert(1);

            // Assert
            bst.Maximum().Should().Be(80);
        }

    }
}