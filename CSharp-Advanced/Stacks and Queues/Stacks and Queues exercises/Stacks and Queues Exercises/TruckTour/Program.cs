using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                pumps.Enqueue(input);

            }

            for (int i = 0; i < numberOfPumps; i++)
            {
                var fuel = 0;
                int pumpChecks = pumps.Count - 1;
                bool foundPath = true;
                for (int j = 0; j < pumpChecks; j++)
                {
                    var pumpFuel = pumps.Peek()[0];
                    var pumpDistance = pumps.Peek()[1];
                    pumps.Enqueue(pumps.Dequeue());
                    fuel += pumpFuel - pumpDistance;

                    if (fuel < 0)
                    {
                        i += j;
                        foundPath = false;
                        break;
                    }
                    
                }
                if (foundPath)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
