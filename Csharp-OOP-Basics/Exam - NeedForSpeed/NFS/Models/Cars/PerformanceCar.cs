using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        base.HorsePower += (this.HorsePower * 50) / 100;
        base.Suspension -= (this.Suspension * 25) / 100;
    }

    public List<string> AddOns
    {
        get => this.addOns;
        private set => this.addOns = value;
    }

    public override string ToString()
    {
        if (this.AddOns.Count != 0)
        {
            return (base.ToString() + $"\r\nAdd-ons: {string.Join(", ", this.AddOns)}").Trim();
        }
        return (base.ToString() + "\r\nAdd-ons: None").Trim();


    }
}
