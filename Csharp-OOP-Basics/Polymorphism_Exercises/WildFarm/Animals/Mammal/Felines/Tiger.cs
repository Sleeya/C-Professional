using System;

public class Tiger : Feline, ISayHungry, IFeedable
{
    public Tiger(string name, double weight, string livingregion, string breed) : base(name, weight, livingregion, breed)
    {
    }

    public override void SayHungry()
    {
        Console.WriteLine("ROAR!!!");
    }

    public override void FeedAnimal(int foodCount)
    {
        base.FoodEaten += foodCount;
        base.Weight += 1.00 * foodCount;
    }
}