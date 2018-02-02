using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        private static List<List<string>> matrix;
        private static int rows;
        private static int columns;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            CreateMatrix(dimensions);

            NukeTheMatrix(dimensions);

            PrintMatrixLastStand();
        }

        private static void PrintMatrixLastStand()
        {
            foreach (var list in matrix)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }

        private static void NukeTheMatrix(int[] dimensions)
        {
            string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (input[0] != "Nuke")
            {
                int nukeRow = int.Parse(input[0]);
                int nukeColumn = int.Parse(input[1]);
                int nukeRadius = int.Parse(input[2]);

                if (nukeRow>=0&& nukeRow < matrix.Count)
                {
                    matrix[nukeRow].RemoveRange(Math.Max(nukeColumn - nukeRadius, 0), Math.Min(nukeRadius * 2 + 1, matrix[nukeRow].Count - Math.Max(nukeColumn - nukeRadius, 0)));
                }
                

                for (int i = 1; i <= nukeRadius; i++)
                {
                    if (nukeRow+i<matrix.Count && matrix[nukeRow+i].Count > nukeColumn && nukeColumn >0)
                    {
                        matrix[nukeRow + i].RemoveAt(nukeColumn);
                    }
                    
                    if (nukeRow-i >= 0 && matrix.Count> nukeRow && matrix[nukeRow-i].Count>nukeColumn && nukeColumn >0)
                    {
                        matrix[nukeRow - i].RemoveAt(nukeColumn);
                    }
                    

                }



                CheckForEmptyRows();

                input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }

        private static void CheckForEmptyRows()
        {


            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row].Count==0)
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }

        private static void CreateMatrix(int[] dimensions)
        {
            rows = dimensions[0];
            columns = dimensions[1];
            matrix = new List<List<string>>();
            int counter = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<string>());

                for (int col = 0; col < columns; col++)
                {
                    matrix[row].Add(counter++.ToString());
                }
            }
        }
    }
}
