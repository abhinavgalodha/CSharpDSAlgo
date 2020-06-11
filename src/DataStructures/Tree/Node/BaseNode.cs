using System;
using System.Diagnostics;

namespace DataStructures.Tree.Node
{
    // Adding the debugger display for easier debugging
    [DebuggerDisplay("NodeValue={Value}")]
    public abstract class BaseNode<T>
    {
        public abstract T Value { get; }

        /*
         * OPERATOR OVERLOADING USED FOR CONVERSION FROM ONE USER DEFINED TO ANOTHER
         * This has been added to address following use cases
         *
         * Use Case: if (currentNode.Value < this.Value)
         *
         * In Above line we always needs to use the .value to refer to the actual object value
         * For brevity, we are adding the Explicit operator overloading, which will allow to write code like
         *
         * New Code: if (currentNode < this)
         */
        public static explicit operator T(BaseNode<T> leafNode)
        {
            if (leafNode == null)
            {
                throw new ArgumentNullException(nameof(leafNode));
            }
            return leafNode.Value;
        }
    }
}
