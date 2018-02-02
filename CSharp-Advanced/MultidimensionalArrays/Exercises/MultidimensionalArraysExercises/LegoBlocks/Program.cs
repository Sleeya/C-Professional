using System;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        private static int[][] firstJagg;
        private static int[][] secondJagg;
        static void Main(string[] args)
        {
            int numberOfArrays = int.Parse(Console.ReadLine());

            CreateJaggedArrays(numberOfArrays);

            bool jaggsMatch = CheckMatch();
            if (jaggsMatch)
            {
                PrintJaggsAsOne();
            }
            else
            {
                int sum = PrintTotalSumOfCells();
                Console.WriteLine($"The total number of cells is: {sum}");
            }
        }

        private static int PrintTotalSumOfCells()
        {
            int sum = 0;
            for (int row = 0; row < firstJagg.Length; row++)
            {
                sum += firstJagg[row].Length + secondJagg[row].Length;
            }

            return sum;
        }

        private static void PrintJaggsAsOne()
        {
            for (int row = 0; row < firstJagg.Length; row++)
            {
                Console.WriteLine($"[{string.Join(", ",firstJagg[row])}, {string.Join(", ",secondJagg[row].Reverse())}]");
            }
        }

        private static bool CheckMatch()
        {
            for (int row = 0; row < firstJagg.Length; row++)
            {
                int sumOfBoth = firstJagg[0].Length + secondJagg[0].Length;
                if (sumOfBoth != firstJagg[row].Length + secondJagg[row].Length)
                {
                    return false;
                }
            }

            return true;
        }


        private static void CreateJaggedArrays(int numberOfArrays)
        {
           
            firstJagg = new int[numberOfArrays][];
            secondJagg = new int[numberOfArrays][];

            for (int row = 0; row < firstJagg.Length; row++)
            {
                int[] input = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                firstJagg[row] = new int[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    firstJagg[row][col] = input[col];
                }
            }

            for (int row = 0; row < secondJagg.Length; row++)
            {
                int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                secondJagg[row] = new int[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    secondJagg[row][col] = input[col];
                }
            }
        }
    }
}
