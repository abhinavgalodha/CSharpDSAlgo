using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Algorithms.Sorting.QuickSort
{
    public class QuickSelect
    {

        public static T Find<T>(ICollection<T> collection, uint positionToFind)
        {
            if(collection == null)
            {
                throw new ArgumentNullException();
            }

            int arrayLength = collection.Count;

            if(positionToFind > arrayLength)
            {
                throw new ArgumentOutOfRangeException(nameof(positionToFind));
            }

            var leftIndex = 0;
            var rightIndex = arrayLength - 1;
            var inputArray = collection.ToArray();
            var comparer = Comparer<T>.Default;

            // Decrementing Index to Find by 1, so that zero based index can be ignored
            positionToFind = positionToFind - 1;

            while (true)
            {
                var partitionIndex = Partition(inputArray, leftIndex, rightIndex, comparer);
                if (partitionIndex == positionToFind)
                {
                    return inputArray[partitionIndex];
                }

                if(positionToFind < partitionIndex)
                {
                    rightIndex = partitionIndex - 1;
                }
                else
                {
                    leftIndex = partitionIndex + 1;
                }

            }
        }

        private static int Partition<T>(T[] arrayToSort, int leftIndex, int rightIndex, Comparer<T> comparer)
        {
            int pivotIndex = new Random().Next(leftIndex, rightIndex);
            T pivotElement = arrayToSort[pivotIndex];

            int partitionIndex = leftIndex;

            // Swap pivot to rightmost element so that we don't need to traverse one extra element in the array.
            arrayToSort.Swap(pivotIndex, rightIndex);

            // Sort the elements w.r.t Pivot
            // Elements to the left are less than the Pivot
            // Elements to the right are greater than the Pivot
            // Traverse all items other than the pivot
            for (int currentIndex = leftIndex; currentIndex <= rightIndex - 1; currentIndex++)
            {
                var currentElement = arrayToSort[currentIndex];
                
                // If item is less than pivot, then swap with the partition Index
                // This would keep ensure that elements less than pivot are on left side of partition index
                if (currentElement.IsLessThanEqualTo(pivotElement, comparer))
                {
                    arrayToSort.Swap(currentIndex, partitionIndex);
                    partitionIndex++;
                }
            }

            // Bring back the Pivot to it's Partition index
            arrayToSort.Swap(partitionIndex, rightIndex);

            return partitionIndex;

        }

    }
}
