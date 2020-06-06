using System.Collections.Generic;

namespace Core
{
    public static partial class Extensions
    {
        public static bool IsEmpty<T>(this Stack<T> stack)
        {
            return stack.Count == 0;
        }

        public static bool IsNotEmpty<T>(this Stack<T> stack)
        {
            return !stack.IsEmpty();
        }
    }
}
