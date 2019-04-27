using Algorithms.Sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Algorithms.Sorting.Factory
{
    public class SortingFactory
    {
        public static IEnumerable<ISort> CreateAllSorters()
        {
            return new Collection<ISort>()
            {
                new MergeSort(),
                new MergeSort1(),
                new QuickSort()
            };
        }

        public static ISort Create(SortingAlgorithms sortingAlgorithm)
        {
            switch (sortingAlgorithm)
            {
                case SortingAlgorithms.MergeSort:
                    return new MergeSort();

                case SortingAlgorithms.MergeSort1:
                    return new MergeSort1();

                case SortingAlgorithms.QuickSort:
                    return new QuickSort();

                default:
                    return new MergeSort();
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
