using System;

public class SonicHarvester:Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement,int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        base.EnergyRequirement /= SonicFactor;
        base.Type = "Sonic";
    }

    private int SonicFactor
    {
        get { return this.sonicFactor; }
        set
        {
            
            this.sonicFactor = value;
        }
    }
}
