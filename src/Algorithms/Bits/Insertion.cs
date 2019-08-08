﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Bits
{
    /*
     *Insertion: You are given two 32-bit numbers, Nand M, and two bit positions, i and
        j. Write a method to insert Minto N such that M starts at bit j and ends at bit i. You
        can assume that the bits j through i have enough space to fit all of M. That is, if
        M = 10011, you can assume that there are at least 5 bits between j and i. You would not, for
        example, have j = 3 and i = 2, because M could not fully fit between bit 3 and bit 2.
        EXAMPLE
        Input: N 10011, i 2, j 6
        Output: N 10001001100
        Hints: # 137, #169, #215
     */
    public partial class Bits
    {
        public static int Insertion(int firstNumber, int secondNumber, int i, int j)
        {
            var shiftLeft = secondNumber << i;
            var result = firstNumber & shiftLeft;
        }
    }
}
