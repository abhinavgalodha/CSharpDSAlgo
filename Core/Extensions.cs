using System;
using System.Collections.Generic;

namespace Core
{
    public static class Extensions
    {
        public static void Swap<T>(this T[] array, uint leftIndex, uint rightIndex)
        {
            array.ThrowIfNull(nameof(array));

            if (leftIndex > array.Length ||
                rightIndex > array.Length)
            {
                T temp = array[leftIndex];
                array[leftIndex] = array[rightIndex];
                array[rightIndex] = temp;
            }

        }

        public static void Swap<T>(this IEnumerable<T> collection, int leftIndex, int rightIndex)
        {
            collection.Swap(leftIndex, rightIndex);
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
