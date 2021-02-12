using System.Collections.Generic;

namespace Algorithms.Search
{
    public static class BinarySearch
    {
        public static int Search(int[] arrayOfInts, int elementToSearch)
        {
            var searchIndex = -1;

            // Gaurd
            if (arrayOfInts == null || 
                arrayOfInts.Length == 0)
            {
                return searchIndex;
            }

            var startIndex = 0;
            var endIndex = arrayOfInts.Length - 1;

            while (startIndex <= endIndex)
            {
                var middleIndex = startIndex + (endIndex - startIndex)/2;
                var middleElement = arrayOfInts[middleIndex];

                if (elementToSearch == middleElement)
                {
                    searchIndex = middleIndex;
                    break;
                }
                else if (elementToSearch > middleElement)
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex - 1;
                }
            }

            return searchIndex;
        }
    }
}
