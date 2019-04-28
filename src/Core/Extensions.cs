using System;
using System.Collections.Generic;

namespace Core
{
    public static class Extensions
    {
        public static void Swap<T>(this IList<T> collection, int leftIndex, int rightIndex)
        {
            collection.ThrowIfNull(nameof(collection));

            if (leftIndex < collection.Count ||
                rightIndex < collection.Count)
            {
                T temp = collection[leftIndex];
                collection[leftIndex] = collection[rightIndex];
                collection[rightIndex] = temp;
            }
        }

        internal static void ThrowIfNull<T>(this T obj, string paramName) where T : class
        {
            if (obj == null)
                throw new ArgumentNullException(paramName);

        }

        internal static void ThrowIfNullOrWhiteSpace(this string inputString, string paramName)
        {
            if (String.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentNullException(paramName);
            }
        }

    }
}
