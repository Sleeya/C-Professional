using System;
using System.Linq;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] jaggedLengths = new int[3];

            for (int i = 0; i < input.Length; i++)
            {
                jaggedLengths[Math.Abs(input[i] % 3)]++;
            }

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[jaggedLengths[0]];
            jaggedArray[1] = new int[jaggedLengths[1]];
            jaggedArray[2] = new int[jaggedLengths[2]];

            int[] indexes = new int[3];
            for (int i = 0; i < input.Length; i++)
            {
                jaggedArray[Math.Abs(input[i] % 3)][indexes[Math.Abs(input[i]%3)]] = input[i];
                indexes[Math.Abs(input[i] % 3)]++;
            }

            foreach (var arr in jaggedArray)
            {
                Console.WriteLine(string.Join(" ",arr));
            }
        }
    }
}
