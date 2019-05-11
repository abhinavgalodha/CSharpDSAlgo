using Algorithms.Test.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Test.Data
{
    public class TestDataFactory
    {
        public static CollectionVerification<int> CreateData(SortingData sortingDataType)
        {
            switch (sortingDataType)
            {
                case SortingData.ArrayEmpty:
                    return new TestDataFactory()._arrayEmpty;

                case SortingData.ArrayOneElement:
                    return new TestDataFactory()._arrayOneElement;
                
                case SortingData.ArrayOddCount:
                    return new TestDataFactory()._arrayOddCount;

                case SortingData.ArrayEvenCount:
                    return new TestDataFactory()._arrayEvenCount;

                case SortingData.ArrayWithDuplicateElements:
                    return new TestDataFactory()._arrayWithDuplicateElements;

                case SortingData.ArrayAlreadySorted:
                    return new TestDataFactory()._arrayAlreadySorted;

                case SortingData.ArrayReverseArray:
                    return new TestDataFactory()._arrayReverseArray;

                case SortingData.ArrayIncludingNegativeNumbers:
                    return new TestDataFactory()._arrayIncludingNegativeNumbers;

                case SortingData.ArrayWithSameNumberRepeating:
                    return new TestDataFactory()._arrayWithSameNumberRepeating;

                default:
                    return new TestDataFactory()._arrayIncludingNegativeNumbers;
            }
        }


        private readonly CollectionVerification<int> _arrayEmpty = new CollectionVerification<int>(
            new int[0],
            new int[0]
        );

        private readonly  CollectionVerification<int> _arrayOneElement = new CollectionVerification<int>(
            new int[] { 5 },
            new int[] { 5 }
        );

        private readonly  CollectionVerification<int> _arrayOddCount = new CollectionVerification<int>(
            new int[] { 4, 12, 1, 3, 9, 7, 2 },
            new int[] { 1, 2, 3, 4, 7, 9, 12 }
        );

        private readonly  CollectionVerification<int> _arrayEvenCount = new CollectionVerification<int>(
            new int[] { 4, 12, 1, 3, 9, 7 },
            new int[] { 1, 3, 4, 7, 9, 12 }
        );

        private readonly CollectionVerification<int> _arrayWithDuplicateElements = new CollectionVerification<int>(
                new int[] { 4, 12, 4, 4, 9, 7 },
            new int[] { 4, 4, 4, 7, 9, 12 }
            );

        private readonly CollectionVerification<int> _arrayAlreadySorted = new CollectionVerification<int>(
                    new int[] { 4, 6, 10, 12, 15, 23, 28, 35 },
                new int[] { 4, 6, 10, 12, 15, 23, 28, 35 }
                );

        private readonly CollectionVerification<int> _arrayReverseArray = new CollectionVerification<int>(
            new int[] { 35, 28, 23, 15, 12, 10, 6, 4 },
            new int[] { 4, 6, 10, 12, 15, 23, 28, 35 }
        );

        private readonly CollectionVerification<int> _arrayIncludingNegativeNumbers = new CollectionVerification<int>(
            new int[] { 12, 15, -23, -4, 6, 10, -35, 28 },
            new int[] { -35, -23, -4, 6, 10, 12, 15, 28 }
        );

        private readonly CollectionVerification<int> _arrayWithSameNumberRepeating = new CollectionVerification<int>(
            new int[] { 12, 12, 12, 12, 12 },
            new int[] { 12, 12, 12, 12, 12 }
        );
    }
}
