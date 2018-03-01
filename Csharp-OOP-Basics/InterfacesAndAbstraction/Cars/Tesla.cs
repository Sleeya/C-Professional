using System;
using System.Collections.Generic;
using System.Text;

public class Tesla : ICar, IElectricCar
{
    public string Model { get; set; }
    public string Color { get; set; }

    public int Battery { get; set; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaak!";
    }

    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"{Color} {GetType()} {Model} with {Battery} Batteries");
        builder.AppendLine($"{Start()}");
        builder.AppendLine($"{Stop()}");

        return builder.ToString().Trim();
    }
}

