using Core;

namespace DataStructures.Tree.Node
{
    public class LeafNode<T> : BaseNode<T>
    {
        public override T Value {get;}

        public LeafNode(T value)
        {
            value.ThrowIfNull(nameof(value));
            this.Value = value;
        }

    }
}
