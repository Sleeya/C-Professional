public abstract class Mammal:Animal
{
    private string livingRegion;


    protected Mammal(string name, double weight,string livingregion) : base(name, weight)
    {
        this.LivingRegion = livingregion;
    }

    public string LivingRegion
    {
        get => this.livingRegion;
        set => this.livingRegion = value;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.livingRegion}, {base.FoodEaten}]";
    }
}
