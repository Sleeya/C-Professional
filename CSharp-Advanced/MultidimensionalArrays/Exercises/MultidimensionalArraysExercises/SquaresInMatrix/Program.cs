using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string[,] matrix = new string[dimensions[0],dimensions[1]];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] input = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = input[columns];
                }
            }

            int equalSquares = 0;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int column = 0; column < matrix.GetLength(1)-1; column++)
                {
                    if (matrix[row, column] == matrix[row, column + 1] && matrix[row,column] == matrix[row + 1, column] && 
                        matrix[row,column]== matrix[row + 1, column + 1])
                    {
                        equalSquares++;
                    }
                }
            }

            if (equalSquares != 0)
            {
                Console.WriteLine(equalSquares);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
