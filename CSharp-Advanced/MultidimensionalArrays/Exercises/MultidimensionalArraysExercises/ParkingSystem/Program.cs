using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    class Program
    {
        private static int[][] matrix;
        
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            matrix = new int[dimensions[0]][];

           
            ParkCars(dimensions[1]);

        }

       

        private static void ParkCars(int columns)
        {
            string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            List<int> bannedRows = new List<int>();
            while (input[0] != "stop")
            {
                int entryRow = int.Parse(input[0]);
                int parkRow = int.Parse(input[1]);
                int parkCol = int.Parse(input[2]);

                int parkDistance = 0;
                bool hasParked = false;
                if (matrix[parkRow]==null)
                {
                    matrix[parkRow] = new int[columns];
                }
                
                if (bannedRows.Contains(parkRow))
                {
                    Console.WriteLine($"Row {parkRow} full");
                    input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    continue;
                    
                }
                if (matrix[parkRow][parkCol] == 0)
                {
                    matrix[parkRow][parkCol] = 1;
                    parkDistance = Math.Abs(parkRow - entryRow) + 1 + parkCol;
                    Console.WriteLine(parkDistance);
                    hasParked = true;
                }
                else
                {
                    for (int col = 1; col <= matrix[parkRow].Length; col++)
                    {
                        if (parkCol - col > 0)
                        {
                            if (matrix[parkRow][parkCol - col] == 0)
                            {
                                matrix[parkRow][parkCol - col] = 1;
                                parkDistance = Math.Abs(parkRow - entryRow) + 1 + parkCol - col;
                                Console.WriteLine(parkDistance);
                                hasParked = true;
                                break;
                            }
                        }
                        if (parkCol + col < matrix[parkRow].Length)
                        {
                            if (matrix[parkRow][parkCol + col] == 0)
                            {
                                matrix[parkRow][parkCol + col] = 1;
                                parkDistance = Math.Abs(parkRow - entryRow) + 1 + parkCol + col;
                                Console.WriteLine(parkDistance);
                                hasParked = true;
                                break;
                            }
                        }
                    }
                }

                if (!hasParked)
                {
                    Console.WriteLine($"Row {parkRow} full");
                    bannedRows.Add(parkRow);
                }

                input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }
        }
    }
}
