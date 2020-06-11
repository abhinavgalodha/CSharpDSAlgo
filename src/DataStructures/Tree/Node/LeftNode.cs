using System;
using System.Diagnostics;
using Core;

namespace DataStructures.Tree.Node
{

    public class LeftNode<T> : BaseNode<T>
    {
        private readonly T _valueToAdd;
        // Usage X.LeftNode = 10
        // Usage X.LeftNode = new LeftNode("parent",new ValueToAdd);

        public LeftNode(BaseNode<T> parentNode, T valueToAdd)
        {
            _valueToAdd = valueToAdd;
            valueToAdd.ThrowIfNull(nameof(valueToAdd));

            if (valueToAdd.IsGreaterThan(parentNode.Value))
            {
                throw new InvalidOperationException("In a BST the LEFT node should be less than the right node.");
            }
        }

        public override T Value => _valueToAdd;
    }

    public class RightNode<T> : BaseNode<T>
    {
        private readonly T _valueToAdd;
        // Usage X.LeftNode = 10
        // Usage X.LeftNode = new LeftNode("parent",new ValueToAdd);

        public RightNode(BaseNode<T> parentNode, T valueToAdd)
        {
            _valueToAdd = valueToAdd;
            valueToAdd.ThrowIfNull(nameof(valueToAdd));

            if (valueToAdd.IsLessThanEqualTo(parentNode.Value))
            {
                throw new InvalidOperationException("In a BST the Right node should be Greater than the right node.");
            }
        }

        public override T Value => _valueToAdd;
    }


}
