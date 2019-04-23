using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var listOfIntegers = new List<int>() { 43, 2, 1, 56, 7, 99, 100 };
            listOfIntegers = new List<int>() { 43 };
            listOfIntegers = new List<int>() { 1, 9, 3, 5, 4, 7 };
            Console.WriteLine("List to be sorted" + listOfIntegers);
            var arrayOfIntegers = listOfIntegers.ToArray();

            MergeSort.Implementation2.Sort(arrayOfIntegers);
           // Console.WriteLine("After sorting" + result);
        }
    }
}
