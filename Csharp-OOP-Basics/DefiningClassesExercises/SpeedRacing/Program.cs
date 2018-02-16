using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


class Program
{
    static void Main(string[] args)
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (int i = 0; i < numberOfCars; i++)
        {
            var inputCar = Console.ReadLine().Split();

            Car currentCar = new Car();
            currentCar.Model = inputCar[0];
            currentCar.FuelAmount = decimal.Parse(inputCar[1]);
            currentCar.FuelConsumptionPerKm = decimal.Parse(inputCar[2]);
            currentCar.Distance = 0;
            cars.Add(currentCar);
        }

        string[] command;
        while ((command = Console.ReadLine().Split())[0] != "End")
        {
            var carModel = command[1];
            var distance = decimal.Parse(command[2]);

            //Car currentCar = cars.Find(x => x.Model == carModel);
            //currentCar.Model = carModel;
            //currentCar.MoveCar(distance, currentCar);

            cars[cars.IndexOf(cars.Find(x=>x.Model==carModel))].MoveCar(distance,cars[cars.IndexOf(cars.Find(x => x.Model == carModel))]);

        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance:f0}");
        }
    }
}

