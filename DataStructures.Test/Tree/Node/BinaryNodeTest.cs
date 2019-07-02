using System.Collections.Generic;
using DataStructures.Tree.Node;
using Xunit;

namespace DataStructures.Test.Tree.Node
{
    public class BinaryNodeTest
    {
        [Fact]
        public void CreateABinaryNodeWith1Value()
        {
            var binaryNode = BinaryNode<int>.CreateABinaryNode(1);
            var result = binaryNode.TraverseInOrder();
        }

        [Fact]
        public void CreateABinaryNodeWith2Values()
        {
            BinaryNode<int>.CreateABinaryNode(1,2);
        }

        [Fact]
        public void CreateABinaryNodeWith3Values()
        {
            BinaryNode<int>.CreateABinaryNode(2,1,3);
        }

        [Fact]
        public void CreateABinaryNodeWith5Values()
        {
            var createdBinaryNode = BinaryNode<int>.CreateABinaryNode(3,4,2,1,5);
            var inOrderTraversalList = createdBinaryNode.TraverseInOrder();

        }
    }
}
