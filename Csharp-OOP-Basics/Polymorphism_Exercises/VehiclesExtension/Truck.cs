using System;

public class Truck:Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }

    public void Drive(double distance)
    {
        if ((base.FuelQuantity - (base.FuelConsumptionPerKm + 1.6) * distance) >= 0)
        {
            base.FuelQuantity -= (base.FuelConsumptionPerKm + 1.6) * distance;
            Console.WriteLine($"Truck travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"Truck needs refueling");
        }
    }

    public void Refuel(double liters)
    {
        if (liters <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if (base.TankCapacity < base.FuelQuantity + liters * 0.95)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
        }
        else
        {
            base.FuelQuantity += liters * 0.95;
        }
    }
}

