using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private CarManager manager;

    public Engine()
    {
        this.isRunning = true;
        this.manager = new CarManager();

    }

    public void Run()
    {


        while (this.isRunning)
        {
            var inputCommand = Console.ReadLine();
            if (inputCommand == "Cops Are Here")
            {
                break;
            }
            var commandArgs = ParseInput(inputCommand);
            DistributeCommands(commandArgs);
        }
    }

    private void DistributeCommands(List<string> commandArgs)
    {
        var command = commandArgs[0];
        commandArgs = commandArgs.Skip(1).ToList();
        string output;

        switch (command)
        {
            case "register":
                int id = int.Parse(commandArgs[0]);
                string type = commandArgs[1];
                string brand = commandArgs[2];
                string model = commandArgs[3];
                int year = int.Parse(commandArgs[4]);
                int horsePower = int.Parse(commandArgs[5]);
                int acceleration = int.Parse(commandArgs[6]);
                int suspension = int.Parse(commandArgs[7]);
                int durability = int.Parse(commandArgs[8]);
                this.manager.Register(id, type, brand, model, year, horsePower, acceleration, suspension, durability);
                break;
            case "check":
                int checkId = int.Parse(commandArgs[0]);
                output = this.manager.Check(checkId);
                Console.WriteLine(output);
                break;
            case "open":
                int raceId = int.Parse(commandArgs[0]);
                string raceType = commandArgs[1];
                int length = int.Parse(commandArgs[2]);
                string route = commandArgs[3];
                int pricePool = int.Parse(commandArgs[4]);
                if (raceType == "TimeLimit")
                {
                    int goldTime = int.Parse(commandArgs[5]);
                    this.manager.Open(raceId, raceType, length, route, pricePool, goldTime);
                }
                else if (raceType == "Circuit")
                {
                    int laps = int.Parse(commandArgs[5]);
                    this.manager.Open(raceId, raceType, length, route, pricePool, laps);
                }
                else
                {
                    this.manager.Open(raceId, raceType, length, route, pricePool);
                }
                break;
            case "participate":
                int carId = int.Parse(commandArgs[0]);
                int participateRaceId = int.Parse(commandArgs[1]);
                this.manager.Participate(carId, participateRaceId);
                break;
            case "start":
                int startRaceId = int.Parse(commandArgs[0]);
                output = this.manager.Start(startRaceId);
                Console.WriteLine(output);
                break;
            case "park":
                int parkCarId = int.Parse(commandArgs[0]);
                this.manager.Park(parkCarId);
                break;
            case "unpark":
                int unparkCarId = int.Parse(commandArgs[0]);
                this.manager.Unpark(unparkCarId);
                break;
            case "tune":
                int tuneIndex = int.Parse(commandArgs[0]);
                string addOn = commandArgs[1];
                this.manager.Tune(tuneIndex, addOn);
                break;

        }
    }

    private List<string> ParseInput(string inputCommand)
    {
        return inputCommand
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
}