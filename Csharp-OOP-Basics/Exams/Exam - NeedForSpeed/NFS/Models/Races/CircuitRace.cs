public class CircuitRace : Race
{
    private int laps;

    public CircuitRace(int length, string route, int prizePool, int laps) : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps
    {
        get => this.laps;
        private set => this.laps = value;
    }
}
