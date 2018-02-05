using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> print = x => Console.WriteLine($"Sir {x}");

            foreach (var name in input)
            {
                print(name);
            }
        }
    }
}
