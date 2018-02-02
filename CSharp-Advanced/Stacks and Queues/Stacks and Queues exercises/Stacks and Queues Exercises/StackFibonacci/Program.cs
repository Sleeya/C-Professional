using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            while (stack.Count!=number+1)
            {
                long temp = stack.Peek();
                long calc = stack.Pop()+stack.Peek();
                stack.Push(temp);
                stack.Push(calc);
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
