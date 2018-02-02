using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();

            int[,] matrix = new int[dimensions[0],dimensions[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] currentNums = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = currentNums[columns];
                }

            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            int sum = 0;
            foreach (var line in matrix)
            {
                sum += line;
            }

            Console.WriteLine(sum);
        }
    }
}
