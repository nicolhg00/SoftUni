using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCols = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int row = rowAndCols[0];
            int col = rowAndCols[1];

            char[,] matrix = new char[row, col];
            int count = 0;
            for (int rows = 0; rows < row; rows++)
            {
                char[] rowValues = Console.ReadLine()
                    .Split(" ")
                    .Select(char.Parse)
                    .ToArray();

                for (int cols = 0; cols < col; cols++)
                {
                    matrix[rows, cols] = rowValues[cols];
                }
            }

            for (int rows = 0; rows <= row - 2; rows++)
            {
                for (int cols = 0; cols <= col - 2; cols++)
                {
                    if (matrix[rows,cols] == matrix[rows, cols +1]&&
                        matrix[rows,cols] == matrix[rows +1, cols]&&
                        matrix[rows,cols] == matrix[rows +1, cols +1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
