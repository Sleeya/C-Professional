using System;

public class Car
{
    private const double FUEL_TANK_CAPACITY = 160;

    private int horsePower;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int horsePower, double fuelAmount, Tyre tyre)
    {
        this.HorsePower = horsePower;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int HorsePower
    {
        get => this.horsePower;
        private set => this.horsePower = value;
    }

    public double FuelAmount
    {
        get => this.fuelAmount;
        set
        {
            if (value > FUEL_TANK_CAPACITY)
            {
                this.fuelAmount = FUEL_TANK_CAPACITY;
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }

    public Tyre Tyre
    {
        get => this.tyre;
        private set => this.tyre = value;
    }

    public void ReduceFuelAmount(int trackLength, double driverFuelConsumption)
    {
        if ((this.FuelAmount - (trackLength * driverFuelConsumption))<0)
        {
            throw new ArgumentException();
        }
        this.FuelAmount -= trackLength * driverFuelConsumption;
    }
}
