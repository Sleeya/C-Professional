using System;

public abstract class Harvester : Player
{
    private string type;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Type
    {
        get => this.type;
        set => this.type = value;
    }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(OreOutput)}");
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
            }
            this.energyRequirement = value;
        }
    }
}
