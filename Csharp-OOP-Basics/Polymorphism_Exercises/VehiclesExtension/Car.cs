using System;

public class Car:Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {

    }

    public void Drive(double distance)
    {
        if ((base.FuelQuantity - (base.FuelConsumptionPerKm + 0.9) * distance) >= 0)
        {
            base.FuelQuantity -= (base.FuelConsumptionPerKm + 0.9) * distance;
            Console.WriteLine($"Car travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"Car needs refueling");
        }
    }

    public void Refuel(double liters)
    {
        if (liters <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if (base.TankCapacity < base.FuelQuantity + liters)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
        }
        else
        {
            base.FuelQuantity += liters;
        }
    }
}