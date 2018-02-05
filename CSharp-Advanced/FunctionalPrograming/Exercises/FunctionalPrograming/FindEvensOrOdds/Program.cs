using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var condition = Console.ReadLine();

            Action<List<int>, int, int> populate = Populate;
            var numbers = new List<int>();
            
            populate(numbers, input[0], input[1]);

            Predicate<int> even = x=> x % 2 == 0;
            Predicate<int> odd = x => x % 2 != 0;

            
            Console.WriteLine($" ",numbers);
            List<int> result = new List<int>();
            if (condition=="even")
            {
                result = numbers.FindAll(even);
            }
            else
            {
                result = numbers.FindAll(odd);
            }

            Console.WriteLine(string.Join(" ",result));

        }

       

        private static void Populate(List<int> ints, int min, int max)
        {
            for (int i  = min; i <= max; i++)
            {
                ints.Add(i);
            }
        }

       
    }
}
