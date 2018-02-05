using System;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());

            Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length <= maxLength)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
