using System;

public class Bus:Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {

    }

    public void Drive(double distance, bool isEmpty)
    {
        if (isEmpty)
        {
            if ((base.FuelQuantity - (base.FuelConsumptionPerKm * distance) >= 0))
            {
                base.FuelQuantity -= base.FuelConsumptionPerKm * distance;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
            }
        }
        else
        {
            if ((base.FuelQuantity - (base.FuelConsumptionPerKm + 1.4) * distance) >= 0)
            {
                base.FuelQuantity -= (base.FuelConsumptionPerKm + 1.4) * distance;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
            }
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
