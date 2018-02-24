using System;
using System.Collections.Generic;
using System.Text;


public class Food
{
    private int happiness;

    public Food(int happyness)
    {
        Happyness = happyness;
    }

    public int Happyness
    {
        get => this.happiness;
        set => this.happiness = value;
    }


}

