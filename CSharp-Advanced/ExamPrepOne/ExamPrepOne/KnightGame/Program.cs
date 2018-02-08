using System;
using System.Data;

namespace KnightGame
{
    class Program
    {
        private static char[,] matrix;
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            matrix = new char[dimensions, dimensions];

            FillTheMatrix(dimensions);

             MoveKnights();

        }

        private static void MoveKnights()
        {
            int knightsRemoved = 0;
            while (true)
            {
                bool needsRemoving = false;

                int[] indexes = new int[2];
                int[] knightIndex = new int[2];
                int attacks = 0;
                int maxAttacks = 0;

                
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            indexes[0] = row;
                            indexes[1] = col;
                            attacks = CountAttacks(row, col);
                            if (attacks > maxAttacks)
                            {
                                maxAttacks = attacks;
                                knightIndex[0] = row;
                                knightIndex[1] = col;
                                needsRemoving = true;
                            }
                        }
                    }
                }

                if (needsRemoving)
                {
                    matrix[knightIndex[0], knightIndex[1]] = 'O';
                    knightsRemoved++;
                }
                else
                {
                    Console.WriteLine(knightsRemoved);
                    Environment.Exit(0);
                }
            }

            
        }
        // row+1,col+2 ...row-1,col+2
        //row+1,col-2...row-1,col-2
        //row+2,col+1...row+2,col-1
        //row-2,col+1...row-2,col-1


        private static int CountAttacks(int row, int col)
        {
            int attacks = 0;
            int num = matrix.GetLength(0)-1;
            if (row+1 <= num && col+2 <= num && matrix[row + 1, col + 2] == 'K')
            {
                attacks++;
            }

            if (row - 1 >= 0 && col + 2 <= num && matrix[row - 1, col + 2] == 'K')
            {
                attacks++;
            }
            if (row + 1 <= num && col -2  >=0 && matrix[row + 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == 'K')
            {
                attacks++;
            }
            if (row + 2 <= num && col + 1 <= num && matrix[row + 2, col + 1] == 'K')
            {
                attacks++;
            }

            if (row + 2 <= num && col -1 >= 0 && matrix[row + 2, col - 1] == 'K')
            {
                attacks++;
            }
            if (row -2 >= 0 && col + 1 <= num && matrix[row - 2, col + 1] == 'K')
            {
                attacks++;
            }

            if (row -2 >= 0 && col - 1 >= 0 && matrix[row - 2, col - 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }

       
        private static void FillTheMatrix(int iterations)
        {
            for (int row = 0; row < iterations; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < iterations; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
