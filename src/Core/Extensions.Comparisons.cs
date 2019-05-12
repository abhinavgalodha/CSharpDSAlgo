using System;
using System.Collections.Generic;

namespace Core
{
    public static partial class Extensions
    {
        public static bool IsLessThanEqualTo<T>(this T leftObject, T rightObject, Comparer<T> comparer)
        {
            return comparer.Compare(leftObject, rightObject) <= 0;
        }

        public static bool IsGreaterThan<T>(this T leftObject, T rightObject, Comparer<T> comparer)
        {
            return !IsLessThanEqualTo(leftObject,rightObject, comparer);
        }
    }
}
