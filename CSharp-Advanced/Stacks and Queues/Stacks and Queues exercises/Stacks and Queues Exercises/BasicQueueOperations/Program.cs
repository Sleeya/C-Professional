using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> commands = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Queue<int> result = new Queue<int>();

            for (int i = 0; i < commands.Peek(); i++)
            {
                result.Enqueue(numbers.Dequeue());
            }
            commands.Dequeue();
            for (int i = 0; i < commands.Peek(); i++)
            {
                result.Dequeue();
            }
            commands.Dequeue();
            if (result.Count ==0)
            {
                Console.WriteLine("0");
            }
            else if (result.Contains(commands.Peek()))
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
