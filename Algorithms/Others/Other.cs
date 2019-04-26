using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Others
{
    public class Other
    {
        public static int GetSmallestPositiveInteger1(int[] arrayOfIntegers)
        {
            int smallestPositiveInteger = int.MaxValue;

            var arrayLength = arrayOfIntegers.Length;

            for (int index = 0; index < arrayLength; index++)
            {
                if(arrayOfIntegers[index] > 0)
                { 
                    if(smallestPositiveInteger > arrayOfIntegers[index])
                    {
                        smallestPositiveInteger = arrayOfIntegers[index];
                    }
                }
            }
            return smallestPositiveInteger;
        }

        public static int GetSmallestPositiveInteger2(int[] arrayOfIntegers)
        {
            var arrayLength = arrayOfIntegers.Length;

            int smallestPositiveInteger = 0;
            bool isPositiveNumberOnceSeen = false;

            
            for (int currentIndex = 0; currentIndex < arrayLength; currentIndex++)
            {
                if(arrayOfIntegers[currentIndex] > 0)
                { 
                    if(isPositiveNumberOnceSeen == false)
                    {
                        smallestPositiveInteger = arrayOfIntegers[currentIndex];
                        isPositiveNumberOnceSeen = true;
                    }
                    
                    if(smallestPositiveInteger > arrayOfIntegers[currentIndex])
                    {
                        smallestPositiveInteger = arrayOfIntegers[currentIndex];
                    }
                }
            }

            // After iteration no +ve integer
            if (smallestPositiveInteger == 0)
            {
                throw new ArgumentException("Input Array doesn't contain any positive integers.");
            }

            return smallestPositiveInteger;
        }

        public static int GetSmallestPositiveInteger(int[] arrayOfIntegers)
        {
            var arrayLength = arrayOfIntegers.Length;

            int? smallestPositiveInteger = null;
            
            for (int currentIndex = 0; currentIndex < arrayLength; currentIndex++)
            {
                if(arrayOfIntegers[currentIndex] > 0)
                { 
                    if(smallestPositiveInteger.GetValueOrDefault() > arrayOfIntegers[currentIndex] ||
                        !smallestPositiveInteger.HasValue)
                    {
                        smallestPositiveInteger = arrayOfIntegers[currentIndex];
                    }
                }
            }

            // After iteration no +ve integer
            if (!smallestPositiveInteger.HasValue)
            {
                throw new ArgumentException("Input Array doesn't contain any positive integers.");
            }

            return smallestPositiveInteger.Value;
        }

    }
}
