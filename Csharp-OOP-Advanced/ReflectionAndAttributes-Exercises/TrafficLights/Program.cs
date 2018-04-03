using System;
using System.Linq;

namespace TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            TrafficLight trafficLight = new TrafficLight(input);

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(trafficLight.Shift());

            }
        }
    }
}
