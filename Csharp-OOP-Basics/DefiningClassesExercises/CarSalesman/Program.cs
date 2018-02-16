using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfEngines = int.Parse(Console.ReadLine());

        List<Engine> engines = new List<Engine>();
        for (int i = 0; i < numberOfEngines; i++)
        {
            var engine = Console.ReadLine().TrimEnd().Split(" ").ToArray();

            Engine currentEngine = new Engine();
            currentEngine.Model = engine[0];
            currentEngine.Power = int.Parse(engine[1]);
            currentEngine.Displacement = "n/a";
            currentEngine.Efficiency = "n/a";

            if (engine.Length>2)
            {
                if (int.TryParse(engine[2], out int num))
                {
                    currentEngine.Displacement = engine[2];
                    if (engine.Length == 4)
                    {
                        currentEngine.Efficiency = engine[3];

                    }

                }
                else
                {
                    currentEngine.Efficiency = engine[2];
                    if (engine.Length == 4)
                    {
                        currentEngine.Displacement = engine[3];

                    }
                }

            }
            
            engines.Add(currentEngine);
        }

        int numberOfCars = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();
        for (int i = 0; i < numberOfCars; i++)
        {
            var carInfo = Console.ReadLine().TrimEnd().Split(" ").ToArray();

            Car currentCar = new Car();
            currentCar.Model = carInfo[0];
            currentCar.Engine = engines.Find(x => x.Model == carInfo[1]);
            currentCar.Weight = "n/a";
            currentCar.Color = "n/a";
            if (carInfo.Length>2)
            {
                int num;
                if (int.TryParse(carInfo[2],out num))
                {
                    currentCar.Weight = carInfo[2];
                    if (carInfo.Length==4)
                    {
                        currentCar.Color = carInfo[3];
                    }
                }
                else
                {
                    currentCar.Color = carInfo[2];
                    if (carInfo.Length == 4)
                    {
                        currentCar.Weight = carInfo[3];
                    }
                }
            }
            cars.Add(currentCar);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($"  {car.Engine.Model}:");
            Console.WriteLine($"    Power: {car.Engine.Power}");
            Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
            Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
            Console.WriteLine($"  Weight: {car.Weight}");
            Console.WriteLine($"  Color: {car.Color}");

        }

    }

}