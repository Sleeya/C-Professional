using System;
using System.Collections.Generic;
using System.Text;


class GandalfEaterOfWorlds
{
    private int happiness;

    public int Happiness
    {
        get => this.happiness;
        set => this.happiness = value;
    }

    public void GandalfEats(List<Food> allTheFood)
    {
        foreach (var food in allTheFood)
        {
            this.Happiness += food.Happyness;
        }
    }
}

