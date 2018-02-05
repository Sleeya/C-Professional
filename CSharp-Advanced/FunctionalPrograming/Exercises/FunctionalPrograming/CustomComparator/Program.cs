using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isOdd = x => x % 2 != 0;
           
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            numbers = numbers.OrderBy(x => x).ToList().OrderBy(x => isOdd(x)).ToList();

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
