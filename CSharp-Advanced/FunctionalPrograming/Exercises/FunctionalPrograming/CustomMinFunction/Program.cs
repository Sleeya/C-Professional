using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> findMinElement = x => FindSmallestELement(x);

            Console.WriteLine(findMinElement(input));

        }

        private static int FindSmallestELement(int[] ints)
        {
            int min = int.MaxValue;
            foreach (var num in ints)
            {
                if (num < min)
                {
                    min = num;
                }
            }

            return min;
        }
    }
}
