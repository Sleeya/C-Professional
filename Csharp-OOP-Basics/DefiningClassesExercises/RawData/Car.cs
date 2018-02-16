using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private string model;
    private Engine engine;
    private List<Tire> tires;
    private Cargo cargo;

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

    public List<Tire> Tires
    {
        get { return this.tires; }
        set { this.tires = value; }
    }

    public Cargo Cargo
    {
        get { return this.cargo; }
        set { this.cargo = value; }
    }

    public Car(string model, Engine engine, List<Tire> tires, Cargo cargo)
    {
        this.model = model;
        this.engine = engine;
        this.tires = tires;
        this.cargo = cargo;
    }
}

