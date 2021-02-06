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

            if (arrayOfInts.Length == 1)
            {
                if (elementToSearch == arrayOfInts[0])
                {
                    return 0;
                }
                else
                {
                    return searchIndex;
                }
            }

            var startIndex = 0;
            var endIndex = arrayOfInts.Length - 1;
            int middleIndex = 0;
            var middleIndexHashSet = new HashSet<int>();

            while (startIndex < endIndex &&
                !middleIndexHashSet.Contains(middleIndex))
            {
                middleIndexHashSet.Add(middleIndex);
                middleIndex = (endIndex + startIndex) % 2 == 0 ? ((endIndex + startIndex) / 2) : ((endIndex + startIndex) / 2) + 1;
                var middleElement = arrayOfInts[middleIndex];

                if (elementToSearch == middleElement)
                {
                    searchIndex = middleIndex - 1;
                    break;
                }
                else if (elementToSearch > middleElement)
                {
                    startIndex = middleIndex + 1;
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
