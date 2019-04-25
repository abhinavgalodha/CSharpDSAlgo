using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    public class MergeSort
    {
        public class Implementation1
        {
            public static void Sort<T>(List<T> listToBeSorted) where T : IComparable<T>
            {
                listToBeSorted = DivideAndSort(listToBeSorted);
            }

            // Divide into SubArrays and Merge
            private static List<T> DivideAndSort<T>(List<T> listToBeSorted) where T : IComparable<T>
            {
                int lengthOfList = listToBeSorted.Count;

                if (lengthOfList <= 1)
                {
                    return listToBeSorted;
                }

                var (leftList, rightList) = Divide(listToBeSorted);
                return Merge(DivideAndSort(leftList), DivideAndSort(rightList));

            }

            private static (List<T>, List<T>) Divide<T>(List<T> listToBeDivided)
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
                var rightList = listToBeDivided.GetRange(midIndex, lengthOfList - (midIndex));

                return (leftList, rightList);
            }

            private static List<T> Merge<T>(List<T> firstListToBeMerged, List<T> secondListToBeMerged) where T : IComparable<T>
            {
                List<T> mergedList = new List<T>();

                var indexFirstList = 0;
                var indexSecondList = 0;

                while (indexFirstList != firstListToBeMerged.Count &&
                       indexSecondList != secondListToBeMerged.Count)
                {
                    var firstListItem = firstListToBeMerged[indexFirstList];
                    var secondListItem = secondListToBeMerged[indexSecondList];

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

                // Merge the remaning as one list is exhausted
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

