using System;

class Program
{
    static void Main(string[] args)
    {
        var carInfo = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
        var truckInfo = Console.ReadLine().Split();
        Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
        var busInfo = Console.ReadLine().Split();
        Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

        int numberOfActions = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfActions; i++)
        {
            var action = Console.ReadLine().Split();
            var actionType = action[0];
            var actionVehicle = action[1];
            if (actionType.StartsWith("Drive"))
            {
                if (actionVehicle == "Car")
                {
                    (car as Car).Drive(double.Parse(action[2]));
                }
                else if (actionVehicle == "Truck")
                {
                    (truck as Truck).Drive(double.Parse(action[2]));
                }
                else if (actionVehicle == "Bus")
                {
                    if (actionType.EndsWith("Empty"))
                    {
                        (bus as Bus).Drive(double.Parse(action[2]), true);
                    }
                    else
                    {
                        (bus as Bus).Drive(double.Parse(action[2]), false);
                    }
                }
            }
            else if (actionType == "Refuel")
            {
                if (actionVehicle == "Car")
                {
                    (car as Car).Refuel(double.Parse(action[2]));
                }
                else if (actionVehicle == "Truck")
                {
                    (truck as Truck).Refuel(double.Parse(action[2]));
                }
                else if (actionVehicle == "Bus")
                {
                    (bus as Bus).Refuel(double.Parse(action[2]));
                }
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
    }
}
