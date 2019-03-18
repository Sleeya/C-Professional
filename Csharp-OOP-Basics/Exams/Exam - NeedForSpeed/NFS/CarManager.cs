using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    private double[] prizeDiviers = { 0.5, 0.3, 0.2 };
    private double[] circuitPrizeDiviers = {0.4, 0.3, 0.2, 0.1};

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();

    }

    public void Register(int id, string type, string brand, string model, int year, int horsePower, int acceleration, int suspension, int durability)
    {

        var car = CarFactory.GenerateCar(type, brand, model, year, horsePower, acceleration, suspension, durability);
        cars[id] = car;
    }

    public string Check(int checkId)
    {
        return cars[checkId].ToString().Trim();
    }

    public void Open(int raceId, string type, int length, string route, int pricePool, int goldTimeOrLaps = 0)
    {
        var race = RaceFactory.GenerateRace(type, length, route, pricePool, goldTimeOrLaps);
        races[raceId] = race;
    }

    public void Participate(int carId, int raceId)
    {
        if (!garage.ParkedCars.Contains(cars[carId]) && races[raceId].RaceStatus == "Open")
        {
            if (races[raceId].GetType().Name == "TimeLimit" && races[raceId].Participants.Count > 0)
            {
                return;
            }
            races[raceId].AddParticipant(cars[carId]);
        }
    }

    public string Start(int raceId)
    {
        var race = races[raceId];
        var raceType = race.GetType().Name;

        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{race.Route} - {race.Length}");

        if (race.Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }
        race.RaceStatus = "Closed";
        switch (raceType)
        {
            case "CasualRace":
                race.OrderByOverall();
                for (int i = 0; i < Math.Min(race.Participants.Count, 3); i++)
                {
                    builder.AppendLine(
                        $"{i + 1}. {race.Participants[i].Brand} {race.Participants[i].Model}" +
                        $" {race.Participants[i].OverallPerformance()}PP - ${race.PrizePool * prizeDiviers[i]}");
                }
                break;
            case "DragRace":
                race.OrderByEngine();
                for (int i = 0; i < Math.Min(race.Participants.Count, 3); i++)
                {
                    builder.AppendLine(
                        $"{i + 1}. {race.Participants[i].Brand} {race.Participants[i].Model}" +
                        $" {race.Participants[i].EnginePerformance()}PP - ${race.PrizePool * prizeDiviers[i]}");
                }
                break;
            case "DriftRace":
                race.OrderBySuspension();
                for (int i = 0; i < Math.Min(race.Participants.Count, 3); i++)
                {
                    builder.AppendLine(
                        $"{i + 1}. {race.Participants[i].Brand} {race.Participants[i].Model}" +
                        $" {race.Participants[i].SuspensionPerformance()}PP - ${race.PrizePool * prizeDiviers[i]}");
                }
                break;
            case "TimeLimitRace":
                var car = race.Participants.FirstOrDefault();
                builder.AppendLine($"{car.Brand} {car.Model} - {((TimeLimitRace) race).TimePerfomrnace()} s.")
                    .AppendLine(((TimeLimitRace) race).EarnedTimeAndPrize());
                break;
            case "CircuitRace":
                for (int i = 0; i < ((CircuitRace)race).Laps; i++)
                {
                    race.Participants.Select(x => x.Durability -= (race.Length * race.Length)).ToList();
                }
                race.OrderByOverall();
                builder.Clear();
                builder.AppendLine($"{race.Route} - {race.Length*((CircuitRace)race).Laps}");
                for (int i = 0; i < Math.Min(race.Participants.Count, 4); i++)
                {
                    builder.AppendLine(
                        $"{i + 1}. {race.Participants[i].Brand} {race.Participants[i].Model}" +
                        $" {race.Participants[i].OverallPerformance()}PP - ${race.PrizePool * circuitPrizeDiviers[i]}");
                }
                break;
        }
        race.Participants.Clear();


        return builder.ToString().Trim();
    }

    public void Park(int carId)
    {

        if (!races.Values.Any(x => x.Participants.Contains(cars[carId])))
        {
            garage.ParkCar(cars[carId]);
        }
    }

    public void Unpark(int carId)
    {
        garage.UnparkCar(cars[carId]);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (garage.ParkedCars.Count > 0)
        {
            foreach (var car in garage.ParkedCars)
            {
                car.HorsePower += tuneIndex;
                car.Suspension += tuneIndex / 2;
                if (car.GetType().Name == "ShowCar")
                {
                    ((ShowCar)car).Stars += tuneIndex;
                }
                else if (car.GetType().Name == "PerformanceCar")
                {
                    ((PerformanceCar)car).AddOns.Add(addOn);
                }
            }
        }
    }
}
