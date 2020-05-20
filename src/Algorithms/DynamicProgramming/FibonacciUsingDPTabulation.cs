using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DynamicProgramming
{
    public class FibonacciUsingDPTabulation
    {
        public long CalculateFibonacci(long number)
        {
            var fib = new int[number+1];
            fib[0] = 0;
            fib[1] = 1;
            
            for (int index = 2; index <= number; index++)
            {
                fib[index] = fib[index - 1] + fib[index - 2];
            }
            return fib[number];
        }
    }
}
