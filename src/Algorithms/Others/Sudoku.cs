using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithms.Others
{
    public class Sudoku
    {
        public static bool IsSudoku(int[,] sudoku)
        {
            // Best case Complexity for Sudoku = Quadratic or linear
            // Best Case complexity for not a sudoku = N

            var isSudoku = true;
            int rowLength = sudoku.GetLength(0);
            int columnLength = sudoku.GetLength(1);

            if(rowLength != columnLength)
            {
                isSudoku = false;
                return isSudoku;
            }

            var expectedSum = (rowLength * (rowLength  + 1))/2;

            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                var rowSum = 0;
                for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                     rowSum = rowSum + sudoku[rowIndex,columnIndex];
                }
                if(rowSum != expectedSum)
                {
                    isSudoku = false;
                    break;
                }
            }
            
            return isSudoku;
        }
    }
}
