using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int num = int.Parse(Console.ReadLine());

            numbers.Reverse();
            numbers.RemoveAll(x => x % num == 0);

            Console.WriteLine(string.Join(" ",numbers));

        }
    }
}
