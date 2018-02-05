using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);


            Func<string, bool> isUpper = x => x[0] == x.ToUpper()[0];

            input = input.Where(isUpper).ToArray();
            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}
