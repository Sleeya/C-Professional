public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    private double speed;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.Speed = (this.Car.HorsePower + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public double TotalTime
    {
        get => this.totalTime;
        set => this.totalTime = value;
    }

    public Car Car
    {
        get => this.car;
        private set => this.car = value;
    }

    public double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm;
        protected set => this.fuelConsumptionPerKm = value;
    }

    public double Speed
    {
        get => this.speed;
        protected set => this.speed = value;
    }

    
}
