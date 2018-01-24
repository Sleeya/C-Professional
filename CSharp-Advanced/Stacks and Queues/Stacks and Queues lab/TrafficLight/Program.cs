using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int treshold = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int counter = 0;
            string car = Console.ReadLine();
            while (car != "end")
            {
                if (car != "green")
                {
                    cars.Enqueue(car);
                }
                else
                {
                    int currentTreshold = Math.Min(treshold, cars.Count);
                    for (int i = 0; i < currentTreshold; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }
                }

                car = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
