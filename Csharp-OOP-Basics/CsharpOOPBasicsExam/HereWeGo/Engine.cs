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
            if (inputCommand == null)
            {
                break;
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
        string output;

        switch (command)
        {
            case "JoinParty":
                output = this.master.JoinParty(commandArgs);
                Console.WriteLine(output);
                break;
            case "AddItemToPool":
                output = this.master.AddItemToPool(commandArgs);
                Console.WriteLine(output);
                break;
            case "PickUpItem":
                output = this.master.PickUpItem(commandArgs);
                Console.WriteLine(output);
                break;
            case "UseItem":
                output = this.master.UseItem(commandArgs);
                Console.WriteLine(output);
                break;
                break;
            case "UseItemOn":
                output = this.master.UseItemOn(commandArgs);
                Console.WriteLine(output);
                break; break;
            case "GiveCharacterItem":
                output = this.master.GiveCharacterItem(commandArgs);
                Console.WriteLine(output);
                break; break;
            case "GetStats":
                output = this.master.GetStats();
                Console.WriteLine(output);
                break; break;
            case "Attack":
                output = this.master.Attack(commandArgs);
                Console.WriteLine(output);
                break; break;
            case "Heal":
                output = this.master.Heal(commandArgs);
                Console.WriteLine(output);
                break; break;
            case "EndTurn":
                output = this.master.EndTurn(commandArgs);
                Console.WriteLine(output);
                break;
            case "IsGameOver":
                Console.WriteLine(this.master.IsGameOver());
                break;
                

        }
    }

    private string[] ParseInput(string inputCommand)
    {
        return inputCommand
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
    }
}