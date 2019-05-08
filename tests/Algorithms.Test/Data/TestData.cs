using Algorithms.Test.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Test.Data
{
    public class TestData
    {
        public static CollectionVerification<int> ArrayEmpty = new CollectionVerification<int>(
            new int[0],
            new int[0]
        );

        public static CollectionVerification<int> ArrayOneElement = new CollectionVerification<int>(
            new int[] { 5 },
            new int[] { 5 }
        );

        public static CollectionVerification<int> ArrayOddCount = new CollectionVerification<int>(
            //new int[] { 4, 12, 1, 3, 9, 7, 2 },
            //new int[] { 1, 2, 3, 4, 7, 9, 12 }
            new int[] { 7,3,1,2,10,4,5 },
            new int[] { 1,2,3,4,5,7,10 }
        );

        public static CollectionVerification<int> ArrayEvenCount = new CollectionVerification<int>(
            new int[] { 4, 12, 1, 3, 9, 7 },
            new int[] { 1, 3, 4, 7, 9, 12 }
        );

        public static CollectionVerification<int> ArrayWithDuplicateElements = new CollectionVerification<int>(
                new int[] { 4, 12, 4, 4, 9, 7 },
            new int[] { 4, 4, 4, 7, 9, 12 }
            );

        public static CollectionVerification<int> ArrayAlreadySorted = new CollectionVerification<int>(
                    new int[] { 4, 6, 10, 12, 15, 23, 28, 35 },
                new int[] { 4, 6, 10, 12, 15, 23, 28, 35 }
                );

        public static CollectionVerification<int> ArrayReverseArray = new CollectionVerification<int>(
            new int[] { 35, 28, 23, 15, 12, 10, 6, 4 },
            new int[] { 4, 6, 10, 12, 15, 23, 28, 35 }
        );

        public static CollectionVerification<int> ArrayIncludingNegativeNumbers = new CollectionVerification<int>(
            new int[] { 12, 15, -23, -4, 6, 10, -35, 28 },
            new int[] { -35, -23, -4, 6, 10, 12, 15, 28 }
        );

        public static CollectionVerification<int> ArrayWithSameNumberRepeating = new CollectionVerification<int>(
            new int[] { 12, 12, 12, 12, 12 },
            new int[] { 12, 12, 12, 12, 12 }
        );
    }
}
