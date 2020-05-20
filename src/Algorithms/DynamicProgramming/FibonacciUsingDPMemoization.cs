using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DynamicProgramming
{
    public class FibonacciUsingDPMemoization
    {
        long[] _lookUp = new long[100];

        public long CalculateFibonacci(long number)
        {
            if (_lookUp[number] != 0)
            {
                if (number <= 1)
                {
                    _lookUp[number] = number;
                }
                else
                {
                    _lookUp[number] = _lookUp[number - 1] + _lookUp[number - 2];
                }

            }
            return _lookUp[number];
        }
    }
}
