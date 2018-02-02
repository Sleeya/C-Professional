using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int triangleHeight = int.Parse(Console.ReadLine());

            long[][] triangle = new long[triangleHeight][];

            for (int row = 0; row < triangleHeight; row++)
            {
                triangle[row] = new long[row+1];
            }

            triangle[0][0] = 1;
            
            for (int rows = 1; rows < triangleHeight; rows++)
            {
                triangle[rows][0] = 1;
                triangle[rows][rows] = 1;
                for (int column = 1; column <= rows-1; column++)
                {
                    triangle[rows][column] = (triangle[rows - 1][column - 1] + triangle[rows - 1][column]);
                }
            }

            foreach (var level in triangle)
            {
                Console.WriteLine(string.Join(" ",level));
            }
        }
    }
}
