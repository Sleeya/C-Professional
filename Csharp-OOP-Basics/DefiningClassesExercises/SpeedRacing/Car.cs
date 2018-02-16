using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Car
{
    private string model;
    private decimal fuelAmount;
    private decimal fuelConsumptionPerKm;
    private decimal distance;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public decimal FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public decimal FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        set { this.fuelConsumptionPerKm = value; }
    }

    public decimal Distance
    {
        get { return this.distance; }
        set { this.distance = value; }
    }

    public void MoveCar(decimal distance,Car currentCar)
    {
        
        if (currentCar.fuelConsumptionPerKm * distance > currentCar.fuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            currentCar.fuelAmount -= currentCar.fuelConsumptionPerKm * distance;
            currentCar.distance += distance;
        }
    }

    
}




