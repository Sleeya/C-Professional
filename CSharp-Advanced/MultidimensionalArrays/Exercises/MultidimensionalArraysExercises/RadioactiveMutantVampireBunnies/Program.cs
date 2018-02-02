using System;
using System.Data;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        private static int columns;
        private static int rows;
        private static char[,] matrix;
        private static int[] playerIndex;
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            columns = dimensions[1];
            rows = dimensions[0];
            matrix = new char[rows, columns];

            FillTheMatrix();

            GameAction();


        }

        private static void GameAction()
        {
            char[] input = Console.ReadLine().ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                bool hasDied = false;
                bool hasExited = false;
                char[,] backupMatrix = (char[,])matrix.Clone();
                switch (input[i])
                {
                    case 'R':
                        if (playerIndex[1] + 1>=columns )
                        {
                            hasExited = true;
                            matrix[playerIndex[0], playerIndex[1]] = '.';
                        }
                        else if (matrix[playerIndex[0], playerIndex[1] + 1] != 'B')
                        {

                            matrix[playerIndex[0], playerIndex[1] + 1] = matrix[playerIndex[0], playerIndex[1]];
                            matrix[playerIndex[0], playerIndex[1]] = '.';
                            playerIndex[1]++;
                        }
                        else
                        {
                            playerIndex[1]++;
                            hasDied = true;

                        }
                        break;
                    case 'L':
                        if (playerIndex[1] - 1 < 0)
                        { 
                            hasExited = true;
                            matrix[playerIndex[0], playerIndex[1]] = '.';
                        }
                        else if (matrix[playerIndex[0], playerIndex[1] - 1] != 'B')
                        {

                            matrix[playerIndex[0], playerIndex[1] - 1] = matrix[playerIndex[0], playerIndex[1]];
                            matrix[playerIndex[0], playerIndex[1]] = '.';
                            playerIndex[1]--;
                        }
                        else
                        {

                            playerIndex[1]--;
                            hasDied = true;
                        }
                        break;
                    case 'U':
                        if (playerIndex[0] - 1 < 0)
                        {
                            hasExited = true;
                            matrix[playerIndex[0], playerIndex[1]] = '.';
                        }
                        else if (matrix[playerIndex[0]-1, playerIndex[1]] != 'B')
                        {

                            matrix[playerIndex[0]-1, playerIndex[1]] = matrix[playerIndex[0], playerIndex[1]];
                            matrix[playerIndex[0], playerIndex[1]] = '.';
                            playerIndex[0]--;
                        }
                        else
                        {
                            playerIndex[0]--;
                            hasDied = true;
                        }
                        break;
                    case 'D':
                        if (playerIndex[0] + 1 >= rows)
                        {
                            hasExited = true;
                            matrix[playerIndex[0], playerIndex[1]] = '.';
                        }
                        else if (matrix[playerIndex[0]+1, playerIndex[1]] != 'B')
                        {

                            matrix[playerIndex[0]+1, playerIndex[1]] = matrix[playerIndex[0], playerIndex[1]];
                            matrix[playerIndex[0], playerIndex[1]] = '.';
                            playerIndex[0]++;
                        }
                        else
                        {
                            playerIndex[0]++;
                            hasDied = true;
                        }
                        break;
                }
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        if (matrix[row, col] == 'B' && backupMatrix[row, col] == 'B')
                        {
                            if (col + 1 < columns)
                            {
                                matrix[row, col + 1] = 'B';
                            }

                            if (col - 1 >= 0)
                            {
                                matrix[row, col - 1] = 'B';
                            }

                            if (row + 1 < rows)
                            {
                                matrix[row + 1, col] = 'B';
                            }

                            if (row - 1 >= 0)
                            {
                                matrix[row - 1, col] = 'B';
                            }

                            if (!hasDied && !hasExited && matrix[playerIndex[0], playerIndex[1]] != 'P')
                            {
                                hasDied = true;
                            }
                        }

                    }
                }

                if (hasDied)
                {
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < columns; col++)
                        {
                            Console.Write(matrix[row,col]);
                        }

                        Console.WriteLine();
                    }
                    Console.WriteLine($"dead: {playerIndex[0]} {playerIndex[1]}");
                    Environment.Exit(0);
                }
                else if (hasExited)
                {
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < columns; col++)
                        {
                            Console.Write(matrix[row, col]);
                        }

                        Console.WriteLine();
                    }
                    Console.WriteLine($"won: {playerIndex[0]} {playerIndex[1]}");
                    Environment.Exit(0);
                }
            }
        }

        private static void FillTheMatrix()
        {
            playerIndex = new int[2];
            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'P')
                    {
                        playerIndex[0] = row;
                        playerIndex[1] = col;
                    }
                }
            }
        }
    }
}
