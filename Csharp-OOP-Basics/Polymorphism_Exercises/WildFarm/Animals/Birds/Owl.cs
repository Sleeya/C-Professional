using System;

public class Owl:Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override void SayHungry()
    {
        Console.WriteLine("Hoot Hoot");
    }

    public override void FeedAnimal(int foodCount)
    {
        base.FoodEaten += foodCount;
        base.Weight += 0.25 * foodCount;
    }
}

