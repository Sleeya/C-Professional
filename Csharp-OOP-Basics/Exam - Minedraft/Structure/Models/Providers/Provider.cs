using System;

public abstract class Provider:Player
{
    private string type;
    private double energyOutput;

    protected Provider(string id,double energyOutput):base(id)
    {
       
        this.EnergyOutput = energyOutput;
    }

    public string Type
    {
        get => this.type;
        set => this.type = value;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;

        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }

            this.energyOutput = value;
        }
    }
}
