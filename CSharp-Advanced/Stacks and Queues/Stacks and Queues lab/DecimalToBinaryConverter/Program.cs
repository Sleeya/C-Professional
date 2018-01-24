using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number==0)
            {
                Console.WriteLine("0");
                return;
            }
            Stack<int> resultStack = new Stack<int>();

            while (number != 0)
            {
              
               resultStack.Push(number%2);
                number /= 2;
            }

            while (resultStack.Count>0)
            {
                Console.Write(resultStack.Pop());
            }

        }
    }
}
