using System;

public class Cat:Feline
{
    public Cat(string name, double weight, string livingregion, string breed) : base(name, weight, livingregion, breed)
    {
    }

    public override void SayHungry()
    {
        Console.WriteLine("Meow");
    }

    public override void FeedAnimal(int foodCount)
    {
        base.FoodEaten += foodCount;
        base.Weight += 0.30 * foodCount;
    }
}