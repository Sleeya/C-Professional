using System;

public class Vehicle:ICar,ITruck
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;

    public Vehicle(double fuelQuantity,double fuelConsumptionPerKm)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumptionPerKm = fuelConsumptionPerKm;

    }

    public double FuelQuantity
    {
        get => this.fuelQuantity;
        set => this.fuelQuantity = value;
    }

    public double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm;
        set => this.fuelConsumptionPerKm = value;
    }

    void ICar.Drive(double distance)
    {
        if ((FuelQuantity - (FuelConsumptionPerKm + 0.9) * distance)>=0)
        {
            FuelQuantity -= (FuelConsumptionPerKm + 0.9) * distance;
            Console.WriteLine($"Car travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"Car needs refueling");
        }
    }

    void ICar.Refuel(double liters)
    {
        FuelQuantity += liters;
    }

    void ITruck.Drive(double distance)
    {
        if ((FuelQuantity - (FuelConsumptionPerKm + 1.6) * distance) >= 0)
        {
            FuelQuantity -= (FuelConsumptionPerKm + 1.6) * distance;
            Console.WriteLine($"Truck travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"Truck needs refueling");
        }
    }

    void ITruck.Refuel(double liters)
    {
        FuelQuantity += liters*0.95;
    }
}
