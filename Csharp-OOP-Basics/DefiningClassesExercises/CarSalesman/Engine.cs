using System;
using System.Collections.Generic;
using System.Text;

class Engine
{
    private string model;
    private int power;
    private string displacement;
    private string efficiency;

    public string Model
    {
        get {return this.model; }
        set { this.model = value; }
    }

    public int Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public string Displacement
    {
        get { return this.displacement; }
        set { this.displacement = value; }
    }

    public string Efficiency
    {
        get { return this.efficiency; }
        set { this.efficiency = value; }
    }
}
