using Algorithms.Sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Algorithms.Sorting.MergeSort;
using Algorithms.Sorting.QuickSort;

namespace Algorithms.Sorting.Factory
{
    public class SortingFactory
    {
        public static IEnumerable<ISortingAlgorithm> CreateAllSorters()
        {
            return new Collection<ISortingAlgorithm>()
            {
                new MergeSortingAlgorithm1(),
                new MergeSortingAlgorithm1(),
                new QuickSortingAlgorithm()
            };
        }

        public static ISortingAlgorithm Create(SortingAlgorithms sortingAlgorithm)
        {
            switch (sortingAlgorithm)
            {
                case SortingAlgorithms.MergeSort:
                    return new MergeSortingAlgorithm();

                case SortingAlgorithms.MergeSort1:
                    return new MergeSortingAlgorithm1();

                case SortingAlgorithms.QuickSort:
                    return new QuickSortingAlgorithm();

                default:
                    return new MergeSortingAlgorithm1();
            }
        }


    }

    public enum SortingAlgorithms
    {
        MergeSort,
        MergeSort1,
        QuickSort
    }
}
