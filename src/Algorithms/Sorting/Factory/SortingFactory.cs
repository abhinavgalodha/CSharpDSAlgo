﻿using Algorithms.Sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Algorithms.Sorting.Factory
{
    public class SortingFactory
    {
        public static IEnumerable<ISortingAlgorithm> CreateAllSorters()
        {
            return new Collection<ISortingAlgorithm>()
            {
                new MergeSortingAlgorithm(),
                new MergeSort1(),
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
                    return new MergeSort1();

                case SortingAlgorithms.QuickSort:
                    return new QuickSortingAlgorithm();

                default:
                    return new MergeSortingAlgorithm();
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
