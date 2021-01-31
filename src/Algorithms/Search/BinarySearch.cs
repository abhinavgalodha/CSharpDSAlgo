using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Search
{
    public static class BinarySearch
    {
        public static int Search(int[] arrayOfInts, int elementToSearch)
        {
            var searchIndex = -1;
            // Gaurd
            if (arrayOfInts == null)
                return searchIndex;

            var startIndex = 0;
            var endIndex = arrayOfInts.Length;
            var middleIndex = 0;

            while (startIndex < endIndex)
            {
                middleIndex = endIndex % 2 == 0 ? (endIndex / 2) : (endIndex / 2) + 1;
                var middleElement = arrayOfInts[middleIndex];

                if (elementToSearch == middleElement)
                {
                    searchIndex = middleIndex;
                    break;
                }
                else if (elementToSearch > middleElement)
                {
                    startIndex = middleIndex;
                }
                else
                {
                    endIndex = middleIndex;
                }
            }

            return searchIndex;
        }
    }
}
