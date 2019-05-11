using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Sorting.Factory;
using Algorithms.Sorting.Interfaces;
using FluentAssertions;
using Xunit;

namespace Algorithms.Test.Sorting
{
    [Trait("Sorting", "MergeSort")]
    public class MergeSortTests : BaseSortTest
    {

        protected override ISortingAlgorithm SortingAlgorithm => SortingFactory.Create(SortingAlgorithms.MergeSort);
    }
}
