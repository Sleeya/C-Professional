using System;
using System.Collections.Generic;
using System.Text;


class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public string Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public string Color
    {
        get { return this.color; }
        set { this.color = value; }
    }
}

