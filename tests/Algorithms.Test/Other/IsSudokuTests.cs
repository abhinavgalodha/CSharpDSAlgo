using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Algorithms.Test.Other
{
    public class IsSudokuTests
    {
        [Fact]
        public void NotASudoku()
        {
            var notASudoku = new int[,]
            {   
                { 4, 6, 3 },
                { 5, -2, 1},
                { 8, 3, 3 }
            };

            var expectedIsSudoku = false;

            var actualsSudoku = Others.Sudoku.IsSudoku(notASudoku);
            actualsSudoku.Should().Be(expectedIsSudoku);
        }

        [Fact]
        public void NotASudokuWithSameSum()
        {
            var notASudoku = new int[,]
            {   
                { 1, 2, 3 },
                { 1, 2, 3 },
                { 1, 2, 3 }
            };

            var expectedIsSudoku = false;

            var actualsSudoku = Others.Sudoku.IsSudoku(notASudoku);
            actualsSudoku.Should().Be(expectedIsSudoku);
        }

        [Fact]
        public void IsASudoku()
        {
            var aSudoku = new int[,]
            {   
                { 1, 2, 3, 4 },
                { 2, 3, 4 ,1 },
                { 3, 4, 1 ,2 },
                { 4, 1, 2 ,3 }
            };

            var expectedIsSudoku = true;

            var actualsSudoku = Others.Sudoku.IsSudoku(aSudoku);
            actualsSudoku.Should().Be(expectedIsSudoku);
        }

        [Fact]
        public void IsASudoku9X9()
        {
            var aSudoku = new int[,]
            {   
               {8,3,5,4,1,6,9,2,7},
               {2,9,6,8,5,7,4,3,1},
               {4,1,7,2,9,3,6,5,8},
               {5,6,9,1,3,4,7,8,2},
               {1,2,3,6,7,8,5,4,9},
               {7,4,8,5,2,9,1,6,3},
               {6,5,2,7,8,1,3,9,4},
               {9,8,1,3,4,5,2,7,6},
               {3,7,4,9,6,2,8,1,5}
            };

            var expectedIsSudoku = true;

            var actualsSudoku = Others.Sudoku.IsSudoku(aSudoku);
            actualsSudoku.Should().Be(expectedIsSudoku);
        }

        [Fact]
        public void IsNotASudoku9X9()
        {
            var notASudoku = new int[,]
            {   
                 {8,3,5,4,1,6,9,2,7},
                 {2,9,6,8,5,7,4,3,1},
                 {4,1,7,2,9,3,6,5,8},
                 {5,6,9,1,3,4,7,8,2},
                 {1,2,3,6,7,8,5,4,9},
                 {7,4,8,5,2,9,1,6,3},
                 {6,5,2,7,8,1,3,9,4},
                 {9,8,1,3,4,5,2,7,6},
                 {3,7,4,9,6,2,8,1,1}
            };

            var expectedIsSudoku = false;

            var actualsSudoku = Others.Sudoku.IsSudoku(notASudoku);
            actualsSudoku.Should().Be(expectedIsSudoku);
        }


    }
}
