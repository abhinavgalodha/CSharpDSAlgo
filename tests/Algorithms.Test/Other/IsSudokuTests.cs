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
        public void IsASudoku()
        {
            var aSudoku = new int[,]
            {   
                { 1, 2, 3 },
                { 2, 3, 1},
                { 3, 1, 2 }
            };

            var expectedIsSudoku = true;

            var actualsSudoku = Others.Sudoku.IsSudoku(aSudoku);
            actualsSudoku.Should().Be(expectedIsSudoku);
        }
    }
}
