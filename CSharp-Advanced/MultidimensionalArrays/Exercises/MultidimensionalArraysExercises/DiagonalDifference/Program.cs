using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix,sizeOfMatrix];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] currentRow = Console.ReadLine().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = currentRow[columns];
                }
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int index = 0; index < matrix.GetLength(0); index++)
            {
                primaryDiagonal += matrix[index, index];
                secondaryDiagonal += matrix[index, matrix.GetLength(1) - 1 - index];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
           
        }
    }
}
