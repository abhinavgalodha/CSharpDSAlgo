using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Algorithms.Sorting
{
    public class QuickSort
    {
        public static void Sort<T>(T[] arrayToSort, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;

            // Shuffle 
            int startIndex = 0;
            int endIndex = arrayToSort.Length - 1;

            InternalSort(arrayToSort, startIndex, endIndex, comparer);

        }

        private static void InternalSort<T>(T[] arrayToSort, int leftIndex, int rightIndex, Comparer<T> comparer)
        {
            if(leftIndex >= rightIndex)
            {
                return;
            }

            int partitionIndex = Partition(arrayToSort, leftIndex, rightIndex, comparer);
            InternalSort(arrayToSort, leftIndex, partitionIndex - 1, comparer);
            InternalSort(arrayToSort, partitionIndex + 1, rightIndex, comparer);
        }

        private static int Partition<T>(T[] arrayToSort, int leftIndex, int rightIndex, Comparer<T> comparer)
        {
            int pivotIndex = leftIndex;
            T pivotElement = arrayToSort[pivotIndex];

            // Sort the elements w.r.t Pivot
            // Elements to the left are less than the Pivot
            // Elements to the right are greater than the Pivot

            // compare the left element with Pivot and swap if necessary

            while (leftIndex <= rightIndex)
            {
                // Elements to the left are less than the Pivot
                // Find the element which is bigger than the pivot, It is out of place and needs to be swapped.
                while (comparer.Compare(arrayToSort[leftIndex], pivotElement) <= 0)
                {
                    leftIndex++;
                }

                // Find the element which is smaller than the pivot, It is out of place and needs to be swapped.
                while (comparer.Compare(pivotElement, arrayToSort[rightIndex]) > 0)
                {
                    rightIndex--;
                }

                // TODO : Need to compare again   if (leftIndex <= rightIndex)
                arrayToSort.Swap(leftIndex, rightIndex);
                leftIndex++;
                rightIndex--;
            }

            // Swap with Pivot index
            arrayToSort.Swap(pivotIndex, rightIndex);
            return pivotIndex;

        }
    }
}
