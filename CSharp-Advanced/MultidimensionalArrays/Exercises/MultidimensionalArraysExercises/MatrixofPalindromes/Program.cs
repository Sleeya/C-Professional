using System;
using System.Linq;

namespace MatrixofPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string[,] matrix = new string[input[0],input[1]];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = alphabet[rows] +""+alphabet[rows + columns]+""+alphabet[rows];
                    Console.Write($"{matrix[rows,columns]+" "}");
                }

                Console.WriteLine();
            }

            
        }
    }
}
