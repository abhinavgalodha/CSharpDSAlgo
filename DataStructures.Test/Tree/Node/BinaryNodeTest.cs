using System.Collections.Generic;
using System.Linq;
using DataStructures.Tree.Node;
using Xunit;
using Xunit.Sdk;


namespace DataStructures.Test.Tree.Node
{
    public class BinaryNodeTest
    {
        [Fact]
        public void CreateABinaryNodeWith1Value()
        {
            List<int> listInputNumbers = new List<int>() {1};
            var binaryNode = BinaryNode<int>.CreateABinaryNode(listInputNumbers.ToArray());
            var result = binaryNode.TraverseInOrder();
            result.ToList().SequenceEqual(listInputNumbers);
        }

        [Fact]
        public void CreateABinaryNodeWith2Values()
        {
            BinaryNode<int>.CreateABinaryNode(1,2);
        }

        [Fact]
        public void CreateABinaryNodeWith3Values()
        {
            List<int> listInputNumbers = new List<int>() {2,1,3};
            var binaryNode = BinaryNode<int>.CreateABinaryNode(listInputNumbers.ToArray());
            var result = binaryNode.TraverseInOrder();
            result.ToList().SequenceEqual(listInputNumbers);
        }

        [Fact]
        public void CreateABinaryNodeWith5Values()
        {
            var createdBinaryNode = BinaryNode<int>.CreateABinaryNode(3,4,2,1,5);
            var inOrderTraversalList = createdBinaryNode.TraverseInOrder();

        }


        [Fact]
        public void CreateARightOnlyUnbalancedTree()
        {
            List<int> listInputNumbers = new List<int>() {3,5,7,9,11};
            var binaryNode = BinaryNode<int>.CreateABinaryNode(listInputNumbers.ToArray());
            var result = binaryNode.TraverseInOrder();
            result.ToList().SequenceEqual(listInputNumbers);

        }


        [Fact]
        public void CreateLeftOnlyUnbalancedTree()
        {
            List<int> listInputNumbers = new List<int>() {30,15,7,4,1};
            var binaryNode = BinaryNode<int>.CreateABinaryNode(listInputNumbers.ToArray());
            var result = binaryNode.TraverseInOrder();
            result.ToList().SequenceEqual(listInputNumbers);

        }
    }
}
