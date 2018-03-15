using System;
using System.Linq;

public class TimeLimitRace : Race
{
    private int goldTime;

    public TimeLimitRace(int length, string route, int prizePool,int goldTime) : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime
    {
        get => this.goldTime;
        private set => this.goldTime = value;
    }

    public int TimePerfomrnace()
    {
        return this.Length * ((this.Participants.FirstOrDefault().HorsePower / 100) *
                              this.Participants.FirstOrDefault().Acceleration);
    }

    public string EarnedTimeAndPrize()
    {
        if (this.TimePerfomrnace() <= this.GoldTime)
        {
            return $"Gold Time, ${this.PrizePool}.";
        }
         if (this.TimePerfomrnace() <= this.GoldTime+15)
        {
            return $"Silver Time, ${this.PrizePool*0.5}.";
        }
         if (this.TimePerfomrnace() > this.GoldTime+15)
        {
            return $"Bronze Time, ${this.PrizePool*0.3}.";
        }

        throw new ArgumentException();
    }
}
