using System;
using System.Collections.Generic;
using System.Text;


class Tire
{
    private decimal pressure;
    private decimal age;

    public decimal Pressure
    {
        get { return this.pressure; }
        set { this.pressure = value; }
    }

    public decimal Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
}

