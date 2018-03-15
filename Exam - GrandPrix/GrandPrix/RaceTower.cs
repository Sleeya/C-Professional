using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int TotalLapsNumber { get; set; }
    private int CurrentLap { get; set; }
    private int TrackLength { get; set; }
    private string Weather { get; set; }
    private List<Driver> drivers;

    public RaceTower(int trackLength, int totalLapsNumber)
    {
        this.drivers = new List<Driver>();
        CurrentLap = 0;
        Weather = "Sunny";
        this.TotalLapsNumber = totalLapsNumber;
        this.TrackLength = trackLength;
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.TotalLapsNumber = lapsNumber;
        this.TrackLength = trackLength;

    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Driver driver = DriverFactory.CreateDriver(commandArgs);
            drivers.Add(driver);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    public void DriverBoxes(List<string> commandArgs)
    {

        string reasonToBox = commandArgs[0];
        string driverName = commandArgs[1];

        drivers.Find(x => x.Name == driverName).TotalTime += 20;
        if (reasonToBox == "ChangeTyres")
        {
            string tyreType = commandArgs[2];
            double tyreHardness = double.Parse(commandArgs[3]);

            drivers.Find(x => x.Name == driverName).Car.Tyre.ChangeHardness(tyreHardness);

            if (tyreType == "Ultrasoft")
            {
                double grip = double.Parse(commandArgs[4]);
                drivers.Find(x => x.Name == driverName).Car.Tyre.ChangeGrip(grip);
            }

        }
        else if (reasonToBox == "Refuel")
        {
            double fuelAmount = double.Parse(commandArgs[2]);
            drivers.Find(x => x.Name == driverName).Car.FuelAmount += fuelAmount;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int lapsToComplete = int.Parse(commandArgs[0]);

        for (int i = 0; i < lapsToComplete; i++)
        {
            foreach (var driver in drivers)
            {
                driver.TotalTime += 60 / (TrackLength / driver.Speed);
                driver.Car.ReduceFuelAmount(TrackLength, driver.FuelConsumptionPerKm);

                if (CurrentLap + lapsToComplete > TotalLapsNumber)
                {
                    throw new ArgumentException($"There is no time! On lap {this.CurrentLap}.");
                }

                driver.Car.Tyre.DegradadeTyre();
            }

            this.CurrentLap++;
        }
    }

    public string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Lap {this.CurrentLap}/{this.TotalLapsNumber}");
        int position = 0;
        foreach (var driver in drivers.OrderBy(x => x.TotalTime))
        {
            builder.AppendLine($"{++position} {driver.Name} {driver.TotalTime}");
        }

        return builder.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        switch (commandArgs[0])
        {
            case "Rainy":
                this.Weather = "Rainy";
                break;
            case "Foggy":
                this.Weather = "Foggy";
                break;
            case "Sunny":
                this.Weather = "Sunny";
                break;
        }
    }

}
