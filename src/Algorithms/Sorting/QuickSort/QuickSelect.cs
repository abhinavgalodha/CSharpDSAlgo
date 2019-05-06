using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Algorithms.Sorting
{
    public class QuickSelect
    {

        public static int Find(int[] array, uint indexToFind)
        {
            if(array == null)
            {
                throw new ArgumentNullException();
            }

            int arrayLength = array.Length;

            if(indexToFind > arrayLength)
            {
                throw new ArgumentOutOfRangeException(nameof(indexToFind));
            }


            // Same Strategy as used in the Quick Sort
            int leftIndex = 0;
            int rightIndex = arrayLength - 1;
            
            //int pivotIndex = (leftIndex + rightIndex) / 2;
            int pivotIndex = new Random().Next(leftIndex, rightIndex);

            while (leftIndex <  rightIndex)
            {

            }


            throw new NotImplementedException();
        }
    }
}
