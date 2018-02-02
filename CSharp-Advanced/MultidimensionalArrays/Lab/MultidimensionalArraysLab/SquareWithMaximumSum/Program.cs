using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[dimensions[0],dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = input[column];
                }
            }

            int sum = int.MinValue;
            int bestSum = int.MinValue;
            int[] bestSquareCords = new int[2];
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int column = 0; column < matrix.GetLongLength(1)-1; column++)
                {
                    sum = matrix[row, column] + matrix[row, column + 1] + matrix[row + 1, column] +
                          matrix[row + 1, column + 1];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestSquareCords[0] = row;
                        bestSquareCords[1] = column;
                    }
                }
            }

            Console.WriteLine($"{matrix[bestSquareCords[0],bestSquareCords[1]]} {matrix[bestSquareCords[0], bestSquareCords[1]+1]}");
            Console.WriteLine($"{matrix[bestSquareCords[0]+1, bestSquareCords[1]]} {matrix[bestSquareCords[0]+1, bestSquareCords[1] + 1]}");
            Console.WriteLine(bestSum);
        }
    }
}
