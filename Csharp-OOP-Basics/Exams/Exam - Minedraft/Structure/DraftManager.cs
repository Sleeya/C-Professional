using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;


    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.mode = "Full";
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;

    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = HarvesterFactory.CreateHarvester(arguments);
            this.harvesters[harvester.Id] = harvester;
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = ProviderFactory.CreateProvider(arguments);
            this.providers[provider.Id] = provider;
            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Day()
    {
        var energyProvided = providers.Values.Sum(x => x.EnergyOutput);
        this.totalStoredEnergy += energyProvided;

        double energyRequired = harvesters.Values.Sum(x => x.EnergyRequirement);
        double oreToBeMined = harvesters.Values.Sum(x => x.OreOutput);
        double todaysMinedOre = 0;
        switch (this.mode)
        {
            case "Full":
                break;
            case "Half":
                energyRequired *= 0.6;
                oreToBeMined *= 0.5;
                break;
            case "Energy":
                energyRequired = 0.0;
                oreToBeMined = 0;
                break;
        }

        if (energyRequired <= totalStoredEnergy)
        {
            this.totalStoredEnergy -= energyRequired;
            this.totalMinedOre += oreToBeMined;
            todaysMinedOre += oreToBeMined;
        }

        StringBuilder builder = new StringBuilder();

        builder.AppendLine("A day has passed.");
        builder.AppendLine($"Energy Provided: {energyProvided}");
        builder.AppendLine($"Plumbus Ore Mined: {todaysMinedOre}");

        return builder.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var newMode = arguments[0];
        if (newMode == "Full" || newMode == "Half" || newMode == "Energy")
        {
            this.mode = newMode;
        }
        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        StringBuilder builder = new StringBuilder();

        if (harvesters.ContainsKey(id))
        {
            builder.AppendLine($"{harvesters[id].Type} Harvester - {id}");
            builder.AppendLine($"Ore Output: {harvesters[id].OreOutput}");
            builder.AppendLine($"Energy Requirement: {harvesters[id].EnergyRequirement}");

            return builder.ToString().Trim();
        }
        if (providers.ContainsKey(id))
        {
            builder.AppendLine($"{providers[id].Type} Provider - {id}");
            builder.AppendLine($"Energy Output: {providers[id].EnergyOutput}");

            return builder.ToString().Trim();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine("System Shutdown");
        builder.AppendLine($"Total Energy Stored: {totalStoredEnergy}");
        builder.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return builder.ToString().Trim();

    }

}
