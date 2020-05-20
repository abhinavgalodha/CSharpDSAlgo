using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DynamicProgramming
{
    public class FibonacciUsingRecursion
    {
        public long CalculateFibonacci(long number)
        {
            if (number <= 1)
            {
                return number;
            }

            return CalculateFibonacci(number - 1) + CalculateFibonacci(number - 2);
        }
    }
}
