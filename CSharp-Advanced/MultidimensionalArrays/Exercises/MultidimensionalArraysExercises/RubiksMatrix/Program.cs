using System;
using System.Linq;
using System.Threading;

namespace RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[dimensions[0],dimensions[1]];
           
            int matrixNumbers = 1;
            for (int row = 0; row < matrix.GetLength(0) ; row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = matrixNumbers;
                    matrixNumbers++;
                }
            }

            
            int numberOfMoves = int.Parse(Console.ReadLine());

            for (int actions = 0; actions < numberOfMoves; actions++)
            {
                string[] input = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                string columnDirection = input[1];
                int moves = int.Parse(input[2]);
                if (columnDirection== "down")
                {
                    int columnIndex = int.Parse(input[0]);
                    
                    int[] tempArray = new int[matrix.GetLength(1)];

                    for (int iteration = 0; iteration < matrix.GetLength(0) ; iteration++)
                    {
                        int replacementIndex = iteration + moves;
                        replacementIndex %= matrix.GetLength(1);
                        tempArray[replacementIndex] = matrix[iteration, columnIndex];

                    }

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        matrix[i, columnIndex] = tempArray[i];
                    }
                  
                }
                
                else if (columnDirection == "up")
                {
                    int columnIndex = int.Parse(input[0]);

                    int[] tempArray = new int[matrix.GetLength(1)];

                    for (int iteration = 0; iteration < matrix.GetLength(0); iteration++)
                    {
                        int replacementIndex = iteration + (matrix.GetLength(0)-moves);
                        replacementIndex %= matrix.GetLength(1);
                        tempArray[replacementIndex] = matrix[iteration, columnIndex];

                    }

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        matrix[i, columnIndex] = tempArray[i];
                    }
                }
                else if (columnDirection == "left")
                {
                    int rowIndex = int.Parse(input[0]);

                    int[] tempArray = new int[matrix.GetLength(0)];

                    for (int iteration = 0; iteration < matrix.GetLength(1); iteration++)
                    {
                        int replacementIndex = iteration + (matrix.GetLength(1) - moves);
                        replacementIndex %= matrix.GetLength(0);
                        tempArray[replacementIndex] = matrix[rowIndex, iteration];

                    }

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        matrix[rowIndex, i] = tempArray[i];
                    }

                }
                else if (columnDirection=="right")
                {
                    int rowIndex = int.Parse(input[0]);

                    int[] tempArray = new int[matrix.GetLength(0)];

                    for (int iteration = 0; iteration < matrix.GetLength(1); iteration++)
                    {
                        int replacementIndex = iteration + moves;
                        replacementIndex %= matrix.GetLength(0);
                        tempArray[replacementIndex] = matrix[rowIndex, iteration];

                    }

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        matrix[rowIndex, i] = tempArray[i];
                    }
                }
                
                

                
            }

            int counter = 1;        
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] != counter)
                    {
                        bool foundMatch = false;
                        for (int rows = 0; rows < matrix.GetLength(0); rows++)
                        {
                            for (int cols = 0; cols < matrix.GetLength(1); cols++)
                            {
                                if (matrix[rows, cols] == counter)
                                {
                                    foundMatch = true;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({rows}, {cols})");
                                    break;
                                }
                            }

                            if (foundMatch)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No swap required");
                    }
                    counter++;
                    
                }
            }
        }
    }
}
