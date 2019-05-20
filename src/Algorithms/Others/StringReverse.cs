using System;
using Core;

namespace Algorithms.Others
{
    public class StringReverse
    {
        public static string Reverse(string inputString)
        {
            var reversedString = inputString.ToCharArray();

            inputString.ThrowIfNullOrWhiteSpace(nameof(inputString));

            // Implementation using finding Mid
            // Next, Check if the number of elements in the Array are even or odd
            // If Odd, then Middle Element can be left and rest should be swapped

            var stringLength = inputString.Length;
            var midIndex = stringLength/2;

            static bool isOdd(int x) => x % 2 != 0;

            var isStringLengthOdd = isOdd(stringLength);

            if (isStringLengthOdd)
            {
                // Swap the elements w.r.t Mid
                for (int currentIndex = 1; currentIndex <= midIndex; currentIndex++)
                {
                    var leftIndex = midIndex - currentIndex;
                    var rightIndex = midIndex + currentIndex;
                    reversedString[currentIndex] = reversedString[currentIndex-1];
                }
            }
            else
            {
                // Swap the elements w.r.t Mid
                for (int currentIndex = 1; currentIndex <= midIndex; currentIndex++)
                {
                    int leftIndex = 0;

                    if (currentIndex == 1)
                    {
                        leftIndex = midIndex;
                    }
                    else
                    {
                        leftIndex = midIndex - currentIndex;
                    }
                        
                    var rightIndex = midIndex +  currentIndex;
                    reversedString[currentIndex] = reversedString[currentIndex-1];
                }
            }
            return new string(reversedString);
        }
    }
}
