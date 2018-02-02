using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine(1);
                Environment.Exit(0);
            }
            Console.WriteLine(recursiveFibonacci(n-1));
        }

        private static long recursiveFibonacci(int n)
        {
            long[] fibonacciNumbers = new long[n + 1];

            fibonacciNumbers[0] = 1;
            fibonacciNumbers[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                fibonacciNumbers[i] =
                    fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2];
            }

            return fibonacciNumbers[n];
        }
    }
}

