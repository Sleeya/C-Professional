using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneaking
{

    class Program
    {
        private static string[,] matrix;
        private static int[] samIndex;
        private static int[] nickIndex;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            InitializeMatrix(rows);

            MoveSam();
        }

        private static void MoveSam()
        {
            string commands = Console.ReadLine();
            for (int i = 0; i < commands.Length; i++)
            {
                MoveEnemys();

                string direction = commands[i].ToString();
                if (direction == "W")
                {
                    continue;
                }

                switch (direction)
                {
                    case "U":
                        matrix[samIndex[0] - 1, samIndex[1]] = "S";
                        matrix[samIndex[0], samIndex[1]] = ".";
                        samIndex[0]--;

                        if (samIndex[0] == nickIndex[0])
                        {
                            matrix[nickIndex[0], nickIndex[1]] = "X";
                            Console.WriteLine($"Nikoladze killed!");
                            PrintExitMatrix();
                        }
                        break;
                    case "D":
                        matrix[samIndex[0] + 1, samIndex[1]] = "S";
                        matrix[samIndex[0], samIndex[1]] = ".";
                        samIndex[0]++;

                        if (samIndex[0] == nickIndex[0])
                        {
                            matrix[nickIndex[0], nickIndex[1]] = "X";
                            Console.WriteLine($"Nikoladze killed!");
                            PrintExitMatrix();
                        }
                        break;
                    case "L":
                        matrix[samIndex[0], samIndex[1]-1] = "S";
                        matrix[samIndex[0], samIndex[1]] = ".";
                        samIndex[1]--;
                        break;
                    case "R":
                        matrix[samIndex[0], samIndex[1] + 1] = "S";
                        matrix[samIndex[0], samIndex[1]] = ".";
                        samIndex[1]++;
                        break;
                }
                PrintExitMatrix();
            }
        }

        private static void MoveEnemys()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                
                for (int col = 0; col < cols; col++)
                {
                    
                    if (matrix[row, col] == "b" && col == cols-1)
                    {
                        matrix[row, col] = "d";

                         if ( samIndex[0] == row && samIndex[1] < col)
                        {
                            Console.WriteLine($"Sam died at {samIndex[0]}, {samIndex[1]}");
                            matrix[samIndex[0], samIndex[1]] = "X";
                            PrintExitMatrix();
                        }
                    }
                    else if (matrix[row, col] == "d" && col == 0)
                    {
                        matrix[row, col] = "b";
                        if ( samIndex[0] == row && samIndex[1] > col)
                        {
                            Console.WriteLine($"Sam died at {samIndex[0]}, {samIndex[1]}");
                            matrix[samIndex[0], samIndex[1]] = "X";
                            PrintExitMatrix();
                        }
                       

                    }
                    
                    else if (matrix[row, col] == "d")
                    {
                        matrix[row, col - 1] = "d";
                        matrix[row, col] = ".";
                        
                       

                    }
                    else if (matrix[row, col] == "b")
                    {
                        matrix[row, col + 1] = "b";
                        matrix[row, col] = ".";
                        col++;

                    }

                   

                }
            }
        }

        private static void PrintExitMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                        Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }

            //Environment.Exit(0);
            Console.WriteLine();
        }

        private static void InitializeMatrix(int rows)
        {

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                if (row == 0)
                {
                    matrix = new string[rows, input.Length];
                }
                for (int col = 0; col < input.Length; col++)
                {
                    if (input[col].ToString() == "S")
                    {
                        samIndex = new int[2];
                        samIndex[0] = row;
                        samIndex[1] = col;
                    }
                    else if (input[col].ToString() == "N")
                    {
                        nickIndex = new int[2];
                        nickIndex[0] = row;
                        nickIndex[1] = col;
                    }
                    matrix[row, col] = input[col].ToString();
                }
            }
        }
    }
}
