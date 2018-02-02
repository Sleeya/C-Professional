using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            Stack<char> checker = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                  checker.Push(input[i]);
                if (checker.Peek()==']')
                {
                    checker.Pop();
                    if (checker.Peek()=='[')
                    {
                        checker.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
                else if (checker.Peek() == ')')
                {
                    checker.Pop();
                    if (checker.Peek() == '(')
                    {
                        checker.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
                else if (checker.Peek() == '}')
                {
                    checker.Pop();
                    if (checker.Peek() == '{')
                    {
                        checker.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
