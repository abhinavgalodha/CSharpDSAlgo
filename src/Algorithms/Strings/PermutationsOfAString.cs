using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Algorithms.Strings
{
    public class PermutationsOfAString
    {
        public static List<string> Create(string inputString)
        {
            // Not sure why it is not working..
            //inputString.ThrowIfNullOrWhiteSpace(inputString);

            List<string> listPermutations = new List<string>();
            listPermutations = CreatePermutations(inputString);
            
            
            /*
            Use recursion.
            Try each of the letters in turn as the first letter and then find all the permutations of the remaining letters using a recursive call.
            The base case is when the input is an empty string the only permutation is the empty string.
            */


            return new List<string>();
        }

        private static List<string> CreatePermutations(string inputString)
        {
            if (inputString.Length == 0)
            {
                return new List<string>();
            }

            for (int index = 0; index < inputString.Length; index++)
            {
                var nthCharacter = inputString[index];
            }
            throw new NotImplementedException();

        }
    }
}
