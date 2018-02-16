using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfTrucks = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (int i = 0; i < numberOfTrucks; i++)
        {
            var input = Console.ReadLine().Split().ToArray();

            string model = input[0];

            Engine currentEngine = new Engine();
            currentEngine.Speed = int.Parse(input[1]);
            currentEngine.Power = int.Parse(input[2]);

            Cargo currentCargo = new Cargo();
            currentCargo.Weight = int.Parse(input[3]);
            currentCargo.Type = input[4];
            
            List<Tire> currentList = new List<Tire>();
            for (int j = 0; j < 4; j++)
            {
                Tire currentTier = new Tire();
                currentTier.Pressure = decimal.Parse(input[5+j+j]);
                currentTier.Age = decimal.Parse(input[6+j+j]);
                currentList.Add(currentTier);
            }
            
            Car currentCar = new Car(model,currentEngine,currentList,currentCargo);
            cars.Add(currentCar);

        }

        string command = Console.ReadLine();

        if (command=="fragile")
        {
            foreach (var car in cars)
            {
                if (car.Cargo.Type == "fragile" && car.Tires.Any(x=>x.Pressure < 1))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
        else if (command == "flamable")
        {
            foreach (var car in cars)
            {
                if (car.Cargo.Type=="flamable" && car.Engine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}

