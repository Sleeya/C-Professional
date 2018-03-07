using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingregion) : base(name, weight, livingregion)
    {
    }

    public override void SayHungry()
    {
        Console.WriteLine("Squeak");
    }

    public override void FeedAnimal(int foodCount)
    {
        base.FoodEaten += foodCount;
        base.Weight += 0.10 * foodCount;
    }
}
