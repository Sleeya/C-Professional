using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar=='(')
                {
                    stack.Push(i);
                }
                else if (currentChar == ')')
                {
                    int startIndex = stack.Pop();

                    string currentBracket = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(currentBracket);
                }
            }
        }
    }
}
