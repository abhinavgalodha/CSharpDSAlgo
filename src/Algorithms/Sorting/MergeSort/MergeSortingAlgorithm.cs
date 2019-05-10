using Algorithms.Sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Algorithms.Sorting
{
    public class MergeSortingAlgorithm : ISortingAlgorithm
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            new Implementation1().Sort<T>(collection);
        }

        public class Implementation1
        {
            // Only using the ref to ensure the collection is modified in the arguments directly...
            public void Sort<T>(IList<T>  listToBeSorted) where T : IComparable<T>
            {
                var sortedListed = DivideAndSort(listToBeSorted);

                // Update the element of the reference;
                for (var index = 0; index < listToBeSorted.Count; index++)
                {
                    listToBeSorted[index] = sortedListed[index];
                }
            }

            // Divide into SubArrays and Merge
            private static IList<T> DivideAndSort<T>(IList<T>  listToBeSorted) where T : IComparable<T>
            {
                int lengthOfList = listToBeSorted.Count;

                if (lengthOfList <= 1)
                {
                    return listToBeSorted;
                }

                var (leftList, rightList) = Divide(listToBeSorted);
                return Merge(DivideAndSort(leftList), DivideAndSort(rightList));

            }

            private static (IList<T> , IList<T>) Divide<T>(IList<T>  listToBeDivided)
            {
                int lengthOfList = listToBeDivided.Count;

                if (lengthOfList == 1)
                {
                    throw new InvalidOperationException("List can't be further divided");
                }

                int lowIndex = 0;
                int midIndex = lengthOfList / 2;
                if (lengthOfList % 2 != 0)
                {
                    // For odd count, increase by 1
                    midIndex = midIndex + 1;
                }

                // left list
                var leftList = listToBeDivided.GetRange(lowIndex, midIndex);

                // right list
                var rightList = listToBeDivided.GetRange(midIndex,(lengthOfList - (midIndex)));

                return (leftList, rightList);
            }

            private static IList<T> Merge<T>(IList<T> firstListToBeMerged, IList<T>  secondListToBeMerged) where T : IComparable<T>
            {
                List<T> mergedList = new List<T>();

                var indexFirstList = 0;
                var indexSecondList = 0;

                // Local Function C# 7
                bool AllElementsNotTraversedInList(IList<T>  list, int index) => list.Count != index;

                while (AllElementsNotTraversedInList(firstListToBeMerged, indexFirstList) &&
                       AllElementsNotTraversedInList(secondListToBeMerged, indexSecondList))
                    
                // Above code using local function is equivalent to below statements.
                //while (indexFirstList != firstListToBeMerged.Count &&
                //       indexSecondList != secondListToBeMerged.Count)
                {
                    T firstListItem = firstListToBeMerged[indexFirstList];
                    T secondListItem = secondListToBeMerged[indexSecondList];

                    if (firstListItem.CompareTo(secondListItem) <= 0)
                    {
                        mergedList.Add(firstListItem);
                        indexFirstList++;
                    }
                    else
                    {
                        mergedList.Add(secondListItem);
                        indexSecondList++;
                    }
                }

                // Merge the renaming as one list is exhausted
                if (indexFirstList == firstListToBeMerged.Count)
                {
                    mergedList.AddRange(secondListToBeMerged.GetRange(indexSecondList, secondListToBeMerged.Count - indexSecondList));
                }
                else
                {
                    mergedList.AddRange(firstListToBeMerged.GetRange(indexFirstList, firstListToBeMerged.Count - indexFirstList));
                }


                return mergedList;
            }
        }

        public class Implementation2
        {
            public static void Sort<T>(T[] arrayToSort) where T : IComparable<T>
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

