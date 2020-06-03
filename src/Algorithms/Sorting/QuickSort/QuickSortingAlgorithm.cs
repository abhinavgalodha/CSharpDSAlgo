using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Sorting.Interfaces;
using Core;

namespace Algorithms.Sorting.QuickSort
{
    public class QuickSortingAlgorithm : ISortingAlgorithm
    {
        public void Sort<T>(IList<T> listToBeSorted) where T : IComparable<T>
        {
            var comparer = Comparer<T>.Default;
            var arrayToSort = listToBeSorted.ToArray();

            // Shuffle 
            int startIndex = 0;
            int endIndex = arrayToSort.Length - 1;

            InternalSort(arrayToSort, startIndex, endIndex, comparer);

            // Update the element of the reference;
            for (var index = 0; index < listToBeSorted.Count; index++)
            {
                listToBeSorted[index] = arrayToSort[index];
            }
        }

        private static void InternalSort<T>(T[] arrayToSort, int leftIndex, int rightIndex, Comparer<T> comparer)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            int partitionIndex = Partition(arrayToSort, leftIndex, rightIndex, comparer);
            InternalSort(arrayToSort, leftIndex, partitionIndex - 1, comparer);
            InternalSort(arrayToSort, partitionIndex + 1, rightIndex, comparer);
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

        //private static int Partition2<T>(T[] arrayToSort, int leftIndex, int rightIndex, Comparer<T> comparer)
        //{
        //    int pivotIndex = new Random().Next(leftIndex, rightIndex);
        //    T pivotElement = arrayToSort[pivotIndex];

        //    while (leftIndex <= rightIndex)
        //    {
        //        // Elements to the left are less than the Pivot
        //        // Find the element which is bigger than the pivot, It is out of place and needs to be swapped.
        //        while (arrayToSort[leftIndex].IsLessThanEqualTo(pivotElement, comparer)
        //               )
        //        {
        //            leftIndex++;
        //        }

        //        // Find the element which is smaller than the pivot, It is out of place and needs to be swapped.
        //        while (pivotElement.IsLessThanEqualTo(arrayToSort[rightIndex], comparer)
        //               )
        //        {
        //            rightIndex--;
        //        }

        //        // TODO : Need to compare again   if (leftIndex <= rightIndex)
        //        if (leftIndex <= rightIndex)
        //        {
        //            arrayToSort.Swap(leftIndex, rightIndex);
        //            leftIndex++;
        //            rightIndex--;
        //        }
        //    }

        //    Swap with Pivot index
        //    arrayToSort.Swap(pivotIndex, rightIndex);
        //    return partitionIndex;

        //}


    }
}
