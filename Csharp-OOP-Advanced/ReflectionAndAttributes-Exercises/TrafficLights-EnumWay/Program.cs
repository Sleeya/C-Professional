using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLights;

namespace TrafficLights_EnumWay
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LightsEnum> input = Console.ReadLine().Split().Select(x=> Enum.Parse(typeof(LightsEnum),x)).Cast<LightsEnum>().ToList();
            TrafficLight trafficLight = new TrafficLight(input);

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(trafficLight.Shift());
            }
        }
    }
}
