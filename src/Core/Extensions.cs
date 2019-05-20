using System;
using System.Collections.Generic;

namespace Core
{
    public static partial class Extensions
    {
        public static void Swap<T>(this IList<T> collection, int leftIndex, int rightIndex)
        {
            collection.ThrowIfNull(nameof(collection));

            if (leftIndex == rightIndex)
            {
                return;
            }

            if (leftIndex < collection.Count ||
                rightIndex < collection.Count)
            {
                T temp = collection[leftIndex];
                collection[leftIndex] = collection[rightIndex];
                collection[rightIndex] = temp;
            }
        }

        /// <summary>
        /// Returns elements in the specified range from the <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="Type"/> of elements in the <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The collection from which elements are to be retrieved.</param>
        /// <param name="index">The 0-based index position in the <paramref name="collection"/> from which elements are to be retrieved.</param>
        /// <param name="count">The number of elements to be retrieved from the <paramref name="collection"/> starting at the <paramref name="index"/>.</param>
        /// <returns>An <see cref="IList{T}"/> object.</returns>
        public static IList<T> GetRange<T>(this IList<T> collection, int index, int count)
        {
            List<T> result = new List<T>();

            for (int i = index; i < index + count; i++)
                result.Add(collection[i]);

            return result;
        }

        public static void ThrowIfNull<T>(this T obj, string paramName) where T : class
        {
            if (obj == null)
                throw new ArgumentNullException(paramName);
        }

        public static void ThrowIfNullOrWhiteSpace(this string inputString, string paramName = "inputParameter")
        {
            if (String.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentNullException(paramName);
            }
            
        }

    }
}
