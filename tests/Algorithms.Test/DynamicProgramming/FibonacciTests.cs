using Algorithms.DynamicProgramming;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Xunit;

namespace Algorithms.Test.DynamicProgramming
{
    public class FibonacciTests
    {
        public static IEnumerable<object[]> TestData { get; } = new List<object[]>
        {
            new object[] {1, 1},
            new object[] {10, 55},
            new object[] {50, 12586269025},
        };


        [Theory]
        [MemberData(nameof(TestData))]
        public void CalculateFibonacciUsingRecursion(long numberToFind, long expectedResult)
        {
            var actualResult = new FibonacciUsingRecursion().CalculateFibonacci(numberToFind);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void CalculateFibonacciUsingDPTabulation(long numberToFind, long expectedResult)
        {
            var actualResult = new FibonacciUsingDPTabulation().CalculateFibonacci(numberToFind);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void CalculateFibonacciUsingDPMemoization(long numberToFind, long expectedResult)
        {
            var actualResult = new FibonacciUsingDPMemoization().CalculateFibonacci(numberToFind);
        }
    }
}
