using System;
using System.Collections.Generic;
using System.Text;


class Topping
{
    private const double MEAT = 1.2;
    private const double VEGGIES = 0.8;
    private const double CHEESE = 1.1;
    private const double SAUCE = 0.9;


    private string type;
    private double weight;
    private double calories;

    private string Type
    {
        get => this.type;
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }

    }

    private double Weight
    {
        get => this.weight;
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
            }

            weight = value;
        }
    }

    public double Calories
    {
        get => this.calories;
        private set { calories = value; }
    }
    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;

        if (Type.ToLower() == "meat")
        {
            calories = 2 * MEAT;
        }
        else if (Type.ToLower() == "veggies")
        {
            calories = 2 * VEGGIES;
        }
        else if (Type.ToLower() == "cheese")
        {
            calories = 2 * CHEESE;
        }
        else if (Type.ToLower() == "sauce")
        {
            calories = 2 * SAUCE;
        }

        calories *= weight;
    }
}
