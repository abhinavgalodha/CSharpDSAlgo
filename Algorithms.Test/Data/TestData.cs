using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Test.Data
{
    public class TestData
    {
        public static CollectionVerification<int> ArrayEmpty = new CollectionVerification<int>()
        {
            Actual = new int[0],
            Expected = new int [0]
        };

        public static CollectionVerification<int> ArrayOneElement = new CollectionVerification<int>()
        {
            Actual = new int[]{5},
            Expected = new int[]{5}
        };

        public static CollectionVerification<int> ArrayOddCount = new CollectionVerification<int>()
        {
            Actual = new int [] {4,12,1,3,9,7,2},
            Expected = new int [] {1,2,3,7,9,12}
        };

        public static CollectionVerification<int> ArrayEvenCount = new CollectionVerification<int>()
        {
            Actual = new int [] {4,12,1,3,9,7},
            Expected = new int [] {1,3,4,7,9,12}
        };

        public static CollectionVerification<int> ArrayWithDuplicateElements = new CollectionVerification<int>()
        {
            Actual = new int [] {4,12,4,4,9,7},
            Expected = new int [] {4,4,4,7,9,12}
        };

        public static CollectionVerification<int> ArrayAlreadySorted = new CollectionVerification<int>()
        {
            Actual = new int [] {4, 6, 10, 12, 15, 23, 28, 35},
            Expected = new int [] {4, 6, 10, 12, 15, 23, 28, 35}
        };

        public static CollectionVerification<int> ArrayReverseArray = new CollectionVerification<int>()
        {
            Actual = new int [] {35, 28, 23, 15, 12, 10, 6, 4},
            Expected = new int [] {4, 6, 10, 12, 15, 23, 28, 35}
        };

        public static CollectionVerification<int> ArrayIncludingNegativeNumbers = new CollectionVerification<int>()
        {
            Actual = new int [] {12, 15, -23, -4 , 6, 10, -35, 28},
            Expected = new int [] {-35, -23, -4, 6, 12, 15, 28}
        };

        public static CollectionVerification<int> ArrayWithSameNumberRepeating = new CollectionVerification<int>()
        {
            Actual = new int [] {12, 12, 12, 12, 12},
            Expected = new int [] {12, 12, 12, 12, 12}
        };

    }
}
