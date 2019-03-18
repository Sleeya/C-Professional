using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsePower;
    private int acceleration;
    private int suspension;
    private int durability;


    protected Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
    {
        this.brand = brand;
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.horsePower = horsePower;
        this.acceleration = acceleration;
        this.suspension = suspension;
        this.durability = durability;
        
    }

    public string Brand
    {
        get => this.brand;
        protected set => this.brand = value;
    }

    public string Model
    {
        get => this.model;
        protected set => this.model = value;
    }

    public int YearOfProduction
    {
        get => this.yearOfProduction;
        protected set => this.yearOfProduction = value;
    }

    public int HorsePower
    {
        get => this.horsePower;
        set => this.horsePower = value;
    }

    public int Acceleration
    {
        get => this.acceleration;
        protected set => this.acceleration = value;
    }

    public int Suspension
    {
        get => this.suspension;
        set => this.suspension = value;
    }

    public int Durability
    {
        get => this.durability;
        set => this.durability = value;
    }

    public int OverallPerformance()
    {
        return (this.HorsePower / this.Acceleration) + (this.Suspension + this.Durability);
    }

    public int EnginePerformance()
    {
        return this.HorsePower / this.Acceleration;
    }

    public int SuspensionPerformance()
    {
        return this.Suspension + this.Durability;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        builder.AppendLine($"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s");
        builder.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return builder.ToString().Trim();
    }


}
