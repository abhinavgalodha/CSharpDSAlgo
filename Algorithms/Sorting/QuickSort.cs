using System;
using System.Collections.Generic;
using System.Text;

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

            // Choose the Pivot

            
            // Keep Choosing Pivot and continue sorting
        }

        private static void InternalSort<T>(T[] arrayToSort, int leftIndex, int rightIndex, Comparer<T> comparer)
        {
            
        }

        private static void Partition<T>(T[] arrayToSort, int leftIndex, int rightIndex, Comparer<T> comparer)
        {
            int pivotIndex = rightIndex;
            T pivotElement = arrayToSort[pivotIndex];

            // Sort the elements w.r.t Pivot
            // Elements to the left are less than the Pivot
            // Elements to the right are greater than the Pivot

            // compare the left element with Pivot and swap if necessary
            T[] lessThanPivot;
            T[] rightThanPivot;
        }



    }
}
