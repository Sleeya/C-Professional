using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> resultStack = new Stack<int>();
            Stack<int> maxNumber = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                Stack<int> currentNums = new Stack<int>(Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

                if (currentNums.Contains(1))
                {
                    if (maxNumber.Count == 0 || maxNumber.Peek() < currentNums.Peek())
                    {
                        maxNumber.Push(currentNums.Peek());
                    }
                    resultStack.Push(currentNums.Pop());
                    
                }
                else if (currentNums.Contains(2))
                {
                    if (resultStack.Peek()==maxNumber.Peek())
                    {
                        maxNumber.Pop();
                    }
                    resultStack.Pop();
                    
                }
                else if (currentNums.Contains(3))
                {
                    Console.WriteLine(maxNumber.Peek());
                }
            }
        }
    }
}
