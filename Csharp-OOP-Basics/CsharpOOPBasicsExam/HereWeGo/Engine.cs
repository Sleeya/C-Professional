using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private DungeonMaster master;

    public Engine()
    {
        this.isRunning = true;
        this.master = new DungeonMaster();

    }

    public void Run()
    {
        while (this.isRunning)
        {
            var inputCommand = Console.ReadLine();
            if (string.IsNullOrEmpty(inputCommand)|| this.master.IsGameOver())
            {
                Console.WriteLine("Final stats:");
                Console.WriteLine(this.master.GetStats());
                this.isRunning = false;
                return;
            }
            var commandArgs = ParseInput(inputCommand);
            try
            {
                DistributeCommands(commandArgs);
            }
            catch (Exception e)
            {
                string exceptionName = e.GetType().Name;
                switch (exceptionName)
                {
                    case "ArgumentException":
                        Console.WriteLine($"Parameter Error: {e.Message}");
                        break;
                    case "InvalidOperationException":
                        Console.WriteLine($"Invalid Operation: {e.Message}");
                        break;
                }
            }
        }
    }

    private void DistributeCommands(string[] commandArgs)
    {
        var command = commandArgs[0];
        commandArgs = commandArgs.Skip(1).ToArray();

        var output = string.Empty;

        switch (command)
        {
            case "JoinParty":
                output = this.master.JoinParty(commandArgs);
                break;
            case "AddItemToPool":
                output = this.master.AddItemToPool(commandArgs);
                break;
            case "PickUpItem":
                output = this.master.PickUpItem(commandArgs);
                break;
            case "UseItem":
                output = this.master.UseItem(commandArgs);
                break;
            case "UseItemOn":
                output = this.master.UseItemOn(commandArgs);
                break; 
            case "GiveCharacterItem":
                output = this.master.GiveCharacterItem(commandArgs);
                break; 
            case "GetStats":
                output = this.master.GetStats();
                break; 
            case "Attack":
                output = this.master.Attack(commandArgs);
                break; 
            case "Heal":
                output = this.master.Heal(commandArgs);
                break; 
            case "EndTurn":
                output = this.master.EndTurn(commandArgs);
                break;
        }

        if (output != string.Empty)
        {
            Console.WriteLine(output);
        }
    }

    private string[] ParseInput(string inputCommand)
    {
        return inputCommand
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
    }
}