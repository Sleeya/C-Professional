using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private RaceTower tower;

    public Engine()
    {
        this.isRunning = true;
        int numberOfLaps = int.Parse(Console.ReadLine());
        int lengthOfTrack = int.Parse(Console.ReadLine());
        this.tower = new RaceTower(lengthOfTrack, numberOfLaps);

    }

    public void Run()
    {
        

        while (this.isRunning)
        {
            var inputCommand = Console.ReadLine();
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
            case "RegisterDriver":
                this.tower.RegisterDriver(commandArgs);
                break;
            case "DriverBoxes":
                this.tower.DriverBoxes(commandArgs);
                break;
            case "CompleteLaps":
                output = this.tower.CompleteLaps(commandArgs);
                Console.WriteLine(output);
                break;
            case "GetLeaderboard":
                output = this.tower.GetLeaderboard();
                Console.WriteLine(output);
                break;
            case "ChangeWeather":
                this.tower.ChangeWeather(commandArgs);
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