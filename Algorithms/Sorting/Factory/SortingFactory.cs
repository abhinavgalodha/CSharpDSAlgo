using Algorithms.Sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Algorithms.Sorting.Factory
{
    public class SortingFactory
    {
        public IEnumerable<ISort> CreateAllSorters()
        {
            return new Collection<ISort>()
            {
                new MergeSort(),
                new MergeSort1(),
                new QuickSort();
            };
        }
    }
}
