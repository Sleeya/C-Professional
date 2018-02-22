using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class Team
{
    private string name;
    private int rating;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        players = new List<Player>();
        rating = 0;
    }

    public IReadOnlyCollection<Player> Players
    {
        get => this.players;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(Player playerName)
    {
        players.Remove(playerName);
    }

    public double CalcTeamRating()
    {
        return players.Sum(x => x.CalculateRating());
    }
}

