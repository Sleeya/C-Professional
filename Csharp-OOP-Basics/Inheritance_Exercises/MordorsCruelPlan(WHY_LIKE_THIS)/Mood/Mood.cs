using System;
using System.Collections.Generic;
using System.Text;


public class Mood
{
    private int happiness;

    public Mood(int happiness)
    {
        Happiness = happiness;
    }
    public int Happiness
    {
        get => this.happiness;
        set => this.happiness = value;
    }
}

