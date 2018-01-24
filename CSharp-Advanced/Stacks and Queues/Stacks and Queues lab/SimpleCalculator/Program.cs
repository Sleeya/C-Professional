using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            Stack<string> stack = new Stack<string>(input.Reverse());
            while (stack.Count>1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string action = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                if (action=="+")
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }
                
            }

            Console.WriteLine(stack.Pop());

        }
    }
}
