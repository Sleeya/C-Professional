public abstract class Bird:Animal
{
    private double wingSize;

    protected Bird(string name, double weight,double wingSize) : base(name, weight)
    {
        this.WingSize = wingSize;
    }

    public double WingSize
    {
        get => this.wingSize;
        set => this.wingSize = value;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {base.Weight}, {base.FoodEaten}]";
    }
}

