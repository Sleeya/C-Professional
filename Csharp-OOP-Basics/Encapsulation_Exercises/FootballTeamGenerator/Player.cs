using System;
using System.Collections.Generic;
using System.Text;


class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name,int endurance, int sprint , int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
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

    public int Endurance
    {
        get => this.endurance;
        private set
        {
            if (!IsValidIndex(value))
            {
                throw new ArgumentException($"Endurance should be between 0 and 100.");
            }
            this.endurance = value;
        }
    }

    public int Sprint
    {
        get => this.sprint;
        private set
        {
            if (!IsValidIndex(value))
            {
                throw new ArgumentException($"Sprint should be between 0 and 100.");
            }
            this.sprint = value;
        }
    }

    public int Dribble
    {
        get => this.dribble;
        private set
        {
            if (!IsValidIndex(value))
            {
                throw new ArgumentException($"Dribble should be between 0 and 100.");
            }
            this.dribble = value;
        }
    }

    public int Passing
    {
        get => this.passing;
        private set
        {
            if (!IsValidIndex(value))
            {
                throw new ArgumentException($"Passing should be between 0 and 100.");
            }
            this.passing = value;
        }
    }

    public int Shooting
    {
        get => this.shooting;
        private set
        {
            if (!IsValidIndex(value))
            {
                throw new ArgumentException($"Shooting should be between 0 and 100.");
            }
            this.shooting = value;
        }
    }


    public bool IsValidIndex(int val)
    {
        return val >= 0 && val <= 100;
    }

    public double CalculateRating()
    {
        return (Endurance+Sprint+Dribble+Passing+Shooting)/5.0;
    }

}

