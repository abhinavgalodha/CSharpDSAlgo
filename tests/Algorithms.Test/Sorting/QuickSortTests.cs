using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Sorting.Factory;
using Algorithms.Sorting.Interfaces;
using Xunit;

namespace Algorithms.Test.Sorting
{
    [Trait("Sorting", "QuickSort")]
    public class QuickSortTests : BaseSortTest
    {
        protected override ISortingAlgorithm SortingAlgorithm => SortingFactory.Create(SortingAlgorithms.QuickSort);
    }
}
