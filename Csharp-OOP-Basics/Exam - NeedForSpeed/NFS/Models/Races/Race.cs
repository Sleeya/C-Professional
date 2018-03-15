using System.Collections.Generic;
using System.Linq;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants;
    private string raceStatus;

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
        this.RaceStatus = "Open";
    }

    public int Length
    {
        get => this.length;
        protected set => this.length = value;
    }

    public string Route
    {
        get => this.route;
        protected set => this.route = value;
    }

    public int PrizePool
    {
        get => this.prizePool;
        protected set => this.prizePool = value;
    }

    public List<Car> Participants
    {
        get => this.participants;
        set => this.participants = value;
    }

    public string RaceStatus
    {
        get => this.raceStatus;
        set => this.raceStatus = value;
    }

    public void AddParticipant(Car car)
    {
        this.participants.Add(car);
    }

    public void OrderByEngine()
    {
       this.Participants =  this.Participants.OrderByDescending(x => x.EnginePerformance()).ToList();
    }

    public void OrderByOverall()
    {
        this.Participants = this.Participants.OrderByDescending(x => x.OverallPerformance()).ToList();
    }

    public void OrderBySuspension()
    {
        this.Participants = this.Participants.OrderByDescending(x => x.SuspensionPerformance()).ToList();
    }

    

    
}
