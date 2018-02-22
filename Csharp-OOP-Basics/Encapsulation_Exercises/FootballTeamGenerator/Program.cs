using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var teams = new List<Team>();



        var command = string.Empty;
        while ((command = Console.ReadLine()) != "END")
        {
            var commandInfo = command.Split(";");
            try
            {
                switch ((commandInfo[0]))
                {
                    case "Team":
                        Team currentTeam = new Team(commandInfo[1]);
                        teams.Add(currentTeam);
                        break;
                    case "Add":
                        AddPlayers(commandInfo, teams);
                        break;
                    case "Remove":
                        RemovePlayers(commandInfo,teams);
                        break;
                    case "Rating":
                        PrintRating(commandInfo, teams);
                        break;

                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void PrintRating(string[] commandInfo, List<Team> teams)
    {
        string teamName = commandInfo[1];
        if (!teams.Exists(x => x.Name == teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");

        }
        else
        {
            double rating = teams.Find(x => x.Name == teamName).CalcTeamRating();
            Console.WriteLine($"{teamName} - {Math.Round(rating)}");
        }
        
    }

    private static void AddPlayers(string[] commandInfo, List<Team> teams)
    {
        string teamName = commandInfo[1];
        if (!teams.Exists(x => x.Name == teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");

        }
        else
        {
            Player currentPlayer = new Player(commandInfo[2], int.Parse(commandInfo[3]), int.Parse(commandInfo[4]),
                int.Parse(commandInfo[5]), int.Parse(commandInfo[6]), int.Parse(commandInfo[7]));
            teams.Find(x => x.Name == teamName).AddPlayer(currentPlayer);
        }
        
    }

    private static void RemovePlayers(string[] commandInfo, List<Team> teams)
    {
        string teamName = commandInfo[1];
        string playerName = commandInfo[2];
        if (!teams.Exists(x => x.Name == teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");

        }
        else if (!teams.Find(x => x.Name == teamName).Players.Any(x => x.Name == playerName))
        {
            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
        }
        else
        {
           var team = teams.Find(x => x.Name == teamName);
            Player player = team.Players.First(x => x.Name == playerName);
            team.RemovePlayer(player);
        }
        
    }

}
