using System;
using System.Collections.Generic;
using Algorithms.Sorting.Interfaces;
using Core;

namespace Algorithms.Sorting.MergeSort
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
            public void Sort<T>(IList<T> listToBeSorted) where T : IComparable<T>
            {
                var sortedListed = DivideAndSort(listToBeSorted);

                // Update the element of the reference;
                for (var index = 0; index < listToBeSorted.Count; index++)
                {
                    listToBeSorted[index] = sortedListed[index];
                }
            }

            // Divide into SubArrays and Merge
            private static IList<T> DivideAndSort<T>(IList<T> listToBeSorted) where T : IComparable<T>
            {
                int lengthOfList = listToBeSorted.Count;

                if (lengthOfList <= 1)
                {
                    return listToBeSorted;
                }

                var (leftList, rightList) = Divide(listToBeSorted);
                return Merge(DivideAndSort(leftList), DivideAndSort(rightList));

            }

            private static (IList<T>, IList<T>) Divide<T>(IList<T> listToBeDivided)
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
                var rightList = listToBeDivided.GetRange(midIndex, (lengthOfList - (midIndex)));

                return (leftList, rightList);
            }

            private static IList<T> Merge<T>(IList<T> firstListToBeMerged, IList<T> secondListToBeMerged) where T : IComparable<T>
            {
                List<T> mergedList = new List<T>();

                var indexFirstList = 0;
                var indexSecondList = 0;

                // Local Function C# 7
                bool AllElementsNotTraversedInList(IList<T> list, int index) => list.Count != index;

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


    }
}

