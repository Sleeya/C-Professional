using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public static Provider CreateProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        if (type == "Solar")
        {
            Provider solarProvider = new SolarProvider(id, energyOutput);
            return solarProvider;

        }
        if (type == "Pressure")
        {
            Provider pressureProvider = new PressureProvider(id, energyOutput);
            return pressureProvider;
        }

        throw new ArgumentException("Provider is not registered, because of it's Type");

    }
}
