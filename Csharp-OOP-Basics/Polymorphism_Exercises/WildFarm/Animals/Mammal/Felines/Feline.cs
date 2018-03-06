public abstract class Feline : Mammal
{
    private string breed;

    public Feline(string name, double weight, string livingregion,string breed) : base(name, weight, livingregion)
    {
        this.Breed = breed;
    }

    public string Breed
    {
        get => this.breed;
        set => this.breed = value;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
    }
}
