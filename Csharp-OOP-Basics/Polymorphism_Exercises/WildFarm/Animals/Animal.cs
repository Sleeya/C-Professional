public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public double Weight
    {
        get => this.weight;
        set => this.weight = value;
    }

    public int FoodEaten
    {
        get => this.foodEaten;
        set => this.foodEaten = value;
    }

    public abstract void SayHungry();

    public abstract void FeedAnimal(int foodCount);

    public abstract override string ToString();

}
