using System.Collections.Generic;
using System.Linq;
using DataStructures.Tree.Node;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;


namespace DataStructures.Test.Tree.Node
{
    public class BinaryNodeTest
    {
        [Theory]
        [InlineData(new int[] { 1 })]            
        [InlineData(new int[] { 1, 2 })]            
        [InlineData(new int[] { 2, 1, 3 })]         
        [InlineData(new int[] { 3, 4, 2, 1, 5 })]         
        [InlineData(new int[] { 3, 5, 7, 9, 11 })]         
        [InlineData(new int[] { 30, 15, 7, 4, 1})]
        public void MyTest(int[] listInputNumbers)
        {
            var binaryNode = BinaryNode<int>.CreateABinaryNode(listInputNumbers);
            var result = binaryNode.TraverseInOrder();
            result.Should().BeEquivalentTo(listInputNumbers);
        }

    }
}
