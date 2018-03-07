using System;

public class Hen:Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }


    public override void SayHungry()
    {
        Console.WriteLine("Cluck");
    }

    public override void FeedAnimal(int foodCount)
    {
        base.FoodEaten += foodCount;
        base.Weight += 0.35 * foodCount;
    }
}
