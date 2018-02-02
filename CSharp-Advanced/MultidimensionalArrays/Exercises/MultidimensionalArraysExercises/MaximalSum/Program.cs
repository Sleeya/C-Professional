using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = input[columns];
                }
            }

            int maxSum = int.MinValue;
            int[] maxSquareStartIndex = new int[2];
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 2; column++)
                {
                    int currentSum = matrix[row, column] + matrix[row, column + 1] + matrix[row, column + 2] +
                                     matrix[row + 1, column] + matrix[row + 1, column + 1] +
                                     matrix[row + 1, column + 2] +
                                     matrix[row+2, column] + matrix[row+2, column + 1] + matrix[row+2, column + 2];
                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        maxSquareStartIndex[0] = row;
                        maxSquareStartIndex[1] = column;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[maxSquareStartIndex[0],maxSquareStartIndex[1]]} {matrix[maxSquareStartIndex[0], maxSquareStartIndex[1]+1]}" +
                              $" {matrix[maxSquareStartIndex[0], maxSquareStartIndex[1]+2]}");
            Console.WriteLine($"{matrix[maxSquareStartIndex[0]+1, maxSquareStartIndex[1]]} {matrix[maxSquareStartIndex[0]+1, maxSquareStartIndex[1] + 1]}" +
                              $" {matrix[maxSquareStartIndex[0]+1, maxSquareStartIndex[1] + 2]}");
            Console.WriteLine($"{matrix[maxSquareStartIndex[0]+2, maxSquareStartIndex[1]]} {matrix[maxSquareStartIndex[0]+2, maxSquareStartIndex[1] + 1]}" +
                              $" {matrix[maxSquareStartIndex[0]+2, maxSquareStartIndex[1] + 2]}");
        }
    }
}
