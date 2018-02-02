using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> operations = new Stack<int>(Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int findElement = operations.Pop();
            int numberOfPops = operations.Pop();
            int numberOfPushes = operations.Pop();

            Stack<int> stack = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse());

            Stack<int> result = new Stack<int>();

            for (int i = 0; i < numberOfPushes; i++)
            {
                result.Push(stack.Pop());
            }

            

            for (int i = 0; i < numberOfPops; i++)
            {
                result.Pop();
            }
            if (result.Count==0)
            {
                Console.WriteLine("0");
            }
            else if (result.Contains(findElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(result.Min());
            }


        }
    }
}
