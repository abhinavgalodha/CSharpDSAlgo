using System;
using Core;

namespace Algorithms.Others
{
    public class StringReverse
    {
        public static string Reverse(string inputString)
        {
            var reversedString = inputString.ToCharArray();

            inputString.ThrowIfNull(nameof(inputString));

            // Implementation using finding Mid
            // Next, Check if the number of elements in the Array are even or odd
            // If Odd, then Middle Element can be left and rest should be swapped

            var stringLength = inputString.Length;
            var midIndex = stringLength / 2;

            static bool isOdd(int x) => x % 2 != 0;

            var isStringLengthOdd = isOdd(stringLength);
            // For String with Odd Count length, the Middle number can be ignored, but for even count length,
            // the Middle element shouldn't be ignored. So by decrementing the right by 1 in case of event count we are also including
            // the Mid point as well
            var effectiveRightIndexDecrement = isStringLengthOdd ? 0 : 1;

            // Swap the elements w.r.t Mid
            for (int currentIndex = 1; currentIndex <= midIndex; currentIndex++)
            {
                var leftIndex = midIndex - currentIndex;
                var rightIndex = midIndex + currentIndex - effectiveRightIndexDecrement;

                reversedString.Swap(leftIndex, rightIndex);
            }

            return new string(reversedString);
        }
    }
}
