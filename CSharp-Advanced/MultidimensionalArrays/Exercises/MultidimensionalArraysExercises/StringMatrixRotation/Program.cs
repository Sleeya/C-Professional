using System;
using System.Collections.Generic;

namespace StringMatrixRotation
{
    
    class Program
    {
        private static List<List<string>> matrix;
        
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            int degrees = int.Parse(action.Substring(7,action.Length-8));

            
            FillTheMatrix();

            PrintTheMatrix(degrees);
        }

        private static void PrintTheMatrix(int degrees)
        {
            int rotations = (degrees / 90) % 4;
            if (rotations == 0)
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    Console.WriteLine(string.Join("",matrix[row]));
                }
            }
            else if (rotations == 3)
            {
                for (int col = matrix[0].Count-1; col >= 0; col--)
                {
                    for (int row = 0; row < matrix.Count; row++)
                    {
                        Console.Write(matrix[row][col]);
                    }

                    Console.WriteLine();
                }
            }
            else if (rotations == 2)
            {
                for (int row = matrix.Count - 1; row >= 0; row--)
                {
                    for (int col = matrix[row].Count-1; col >= 0; col--)
                    {
                        Console.Write(matrix[row][col]);
                    }

                    Console.WriteLine();
                }
            }
            else 
            {
               for (int col = 0; col < matrix[0].Count; col++)
                {
                   for (int row = matrix.Count-1 ; row >= 0; row--)
                    {
                        Console.Write(matrix[row][col]);
                    }

                    Console.WriteLine();
                }
            }
            
        }

        private static void FillTheMatrix()
        {
            int longestWord = 0;
            matrix= new List<List<string>>();
            string input = Console.ReadLine();
            
            int counter = 0;
            while (input!="END")
            {
                if (input.Length > longestWord)
                {
                    longestWord = input.Length;
                }
                matrix.Add(new List<string>());
                for (int letters = 0; letters < input.Length; letters++)
                {
                    matrix[counter].Add(input[letters].ToString());
                }

                counter++;
                input = Console.ReadLine();
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                int elementsNeeded = longestWord - matrix[row].Count;
                for (int col = 0; col < elementsNeeded ; col++)
                {
                    matrix[row].Add(" ");
                }
            }
        }
    }
}
