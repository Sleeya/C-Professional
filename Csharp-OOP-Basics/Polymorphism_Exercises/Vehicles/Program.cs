using System;

class Program
{
    static void Main(string[] args)
    {
        var carInfo = Console.ReadLine().Split();
        ICar car = new Vehicle(double.Parse(carInfo[1]),double.Parse(carInfo[2]));
        var truckInfo = Console.ReadLine().Split();
        ITruck truck = new Vehicle(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

        int numberOfActions = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfActions; i++)
        {
            var action = Console.ReadLine().Split();
            var actionType = action[0];
            var actionVehicle = action[1];
            if (actionType == "Drive")
            {
                if (actionVehicle=="Car")
                {
                    car.Drive(double.Parse(action[2]));
                }
                else if (actionVehicle == "Truck")
                {
                    truck.Drive(double.Parse(action[2]));
                }
            }
            else if (actionType == "Refuel")
            {
                if (actionVehicle == "Car")
                {
                    car.Refuel(double.Parse(action[2]));
                }
                else if (actionVehicle == "Truck")
                {
                    truck.Refuel(double.Parse(action[2]));
                }
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
    }
}

