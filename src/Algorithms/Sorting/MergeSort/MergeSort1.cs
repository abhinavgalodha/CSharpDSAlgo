using Algorithms.Sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    public class MergeSort1 : ISortingAlgorithm
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            new Implementation2().Sort<T>(collection.ToArray());
        }

        public class Implementation2
        {
            public void Sort<T>(T[] arrayToSort) where T : IComparable<T>
            {
                var auxArray = new T[arrayToSort.Length];
                Sort(arrayToSort, auxArray, 0, arrayToSort.Length - 1);
            }

            public static void Sort<T>(T[] originalArray, T[] auxArray, int lowerBound, int high)  where T : IComparable<T>
            {
                if(lowerBound >= high)
                {
                    return;
                }

                int mid = lowerBound + (high - lowerBound)/2;

                Sort(originalArray, auxArray, lowerBound, mid);
                Sort(originalArray, auxArray, mid + 1, high);
                Merge(originalArray, auxArray, lowerBound, mid, high);
            }

            public static void Merge<T>(T[] originalArray, T[] auxArray, int lowerBound, int mid, int high) where T : IComparable<T>
            {
                // firstly copy data from original to auxArray
                for (int copyIndex = lowerBound; copyIndex <= high; copyIndex++)
                {
                    auxArray[copyIndex] = originalArray[copyIndex];
                }

                var leftArrayIndex = lowerBound;
                var rightArrayIndex = mid + 1;

                for (int index = lowerBound; index <= high; index++)
                {
                    if (leftArrayIndex > mid)
                    {
                        originalArray[index] = auxArray[rightArrayIndex];
                        rightArrayIndex++;
                    }
                    else if (rightArrayIndex > high)
                    {
                        originalArray[index] = auxArray[leftArrayIndex];
                        leftArrayIndex++;
                    }
                    else if (auxArray[leftArrayIndex].CompareTo(auxArray[rightArrayIndex]) <= 0)
                    {
                        originalArray[index] = auxArray[leftArrayIndex];
                        leftArrayIndex++;
                    }
                    else
                    {
                        originalArray[index] = auxArray[rightArrayIndex];
                        rightArrayIndex++;
                    }
                }
            }
        }

    }
}

