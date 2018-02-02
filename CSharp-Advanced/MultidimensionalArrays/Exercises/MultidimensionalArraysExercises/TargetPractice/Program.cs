using System;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int[] impacts = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int impactRow = impacts[0];
            int impactColumn = impacts[1];
            int impactRadius = impacts[2];

            char[,] matrix = new char[dimensions[0],dimensions[1]];
            int snakeIndex = 0;
            bool goLeft = true;
            for (int row = matrix.GetLength(0)-1; row >=0 ; row--)
            {
                if (goLeft)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex > snake.Length - 1)
                        {
                            snakeIndex = 0;
                        }
                    }
                    goLeft = false;
                    continue;
                }
                else if(!goLeft)
                {
                    for (int col =0 ; col < matrix.GetLength(1) ; col++)
                    {
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex > snake.Length - 1)
                        {
                            snakeIndex = 0;
                        }
                    }
                    goLeft = true;
                    continue;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int a = impactRow - row;
                    int b = impactColumn - col;

                    double distance = Math.Sqrt(a * a + b * b);

                    if (distance<= impactRadius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            for (int col = matrix.GetLength(1) - 1; col >= 0 ; col--)
            {
                int emptySpaces = 0;
                for (int row = matrix.GetLength(0) -1; row >=0 ; row--)
                {
                    if (matrix[row,col] == ' ')
                    {
                        emptySpaces++;
                    }
                    else if (matrix[row,col] != ' ' && emptySpaces>0)
                    {
                        matrix[row + emptySpaces, col ] = matrix[row, col];
                        matrix[row, col] = ' ';
                        
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
