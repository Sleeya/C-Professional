using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ").ToArray();

        List<Food> allTheFood = new List<Food>();
        foreach (var food in input)
        {
            allTheFood.Add(FoodFactory.ProduceFoodObject(food));
        }
        GandalfEaterOfWorlds gandy = new GandalfEaterOfWorlds();

        gandy.GandalfEats(allTheFood);

        Console.WriteLine(gandy.Happiness);
        Console.WriteLine(MoodFactory.GetMood(gandy.Happiness));
    }
}
