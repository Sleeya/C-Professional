using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            Queue<long> sequence = new Queue<long>();
            Queue<long> result = new Queue<long>();
            sequence.Enqueue(number);
            result.Enqueue(number);
            while (result.Count<50)
            { 
               
                number = sequence.Dequeue();
                sequence.Enqueue(number + 1);
                sequence.Enqueue((2 * number) + 1);
                sequence.Enqueue(number + 2);
                result.Enqueue(number + 1);
                result.Enqueue((2 * number) + 1);
                result.Enqueue(number + 2);
               

            }
            for (int i = 0; i < 50; i++)
            {
                Console.Write(result.Dequeue()+" ");
            }
        }
    }
}
