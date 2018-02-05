using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {

            int maxNum = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<List<int>,int,List<int>> populate = Populate;

            List<int> numbers = new List<int>();
            populate(numbers, maxNum);

            Func<int,int[],bool> isDividable = IsDividable;

            foreach (var num in numbers)
            {
                if (isDividable(num,dividers))
                {
                    Console.Write(num+" ");
                }
            }


        }

       

        private static bool IsDividable(int i,int[] dividers)
        {
            bool isDiviseable = false;
            foreach (var divider in dividers)
            {
                if (i % divider != 0)
                {
                    return isDiviseable;
                }
            }

            return true;
        }

        private static List<int> Populate(List<int> ints, int i)
        {
            for (int j = 1; j <= i; j++)
            {
                ints.Add(j);
            }

            return ints;
        }
    }
}
