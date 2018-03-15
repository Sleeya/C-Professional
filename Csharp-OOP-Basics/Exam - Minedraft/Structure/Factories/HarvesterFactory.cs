using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public static Harvester CreateHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        if (type == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            Harvester sonicHarvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
            return sonicHarvester;

        }
        if (type == "Hammer")
        {
            Harvester hammerHarvester = new HammerHarvester(id, oreOutput, energyRequirement);
            return hammerHarvester;
        }

        throw new ArgumentException("Harvester is not registered, because of it's Type");

    }
}

