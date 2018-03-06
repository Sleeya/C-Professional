using System;

public class Dog : Mammal, ISayHungry, IFeedable
{
    public Dog(string name, double weight, string livingregion) : base(name, weight, livingregion)
    {

    }

    public override void SayHungry()
    {
        Console.WriteLine("Woof!");
    }

    public override void FeedAnimal(int foodCount)
    {
        base.FoodEaten += foodCount;
        base.Weight += 0.40 * foodCount;
    }
}
