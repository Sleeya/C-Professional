using System;

public class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
    {
        TankCapacity = tankCapacity;
        FuelQuantity = fuelQuantity;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public double FuelQuantity
    {
        get => this.fuelQuantity;
        set
        {
            if (TankCapacity < value)
            {
                this.fuelQuantity = 0;
            }
            else
            {
                this.fuelQuantity = value;
            }
        }
    }

    public double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm;
        set => this.fuelConsumptionPerKm = value;
    }

    public double TankCapacity
    {
        get => this.tankCapacity;
        set => this.tankCapacity = value;
    }
}
