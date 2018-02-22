using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        int numberOfPlayers = int.Parse(Console.ReadLine());
        List<Person> players = new List<Person>();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            try
            {
                var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    decimal.Parse(cmdArgs[3]));

                players.Add(person);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        Team currentTeam = new Team("Стражите");
        foreach (var player in players)
        {
            currentTeam.AddPlayer(player);
        }

        Console.WriteLine($"First team has {currentTeam.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {currentTeam.ReserveTeam.Count} players.");
    }
}

