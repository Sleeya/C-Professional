using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfPeople = int.Parse(Console.ReadLine());
        List<IBuyer> buyers = new List<IBuyer>();

        AddBuyers(numberOfPeople, buyers);
        GetFood(buyers);
        PrintTotalFood(buyers);

    }

    private static void PrintTotalFood(List<IBuyer> buyers)
    {
        Console.WriteLine(buyers.Sum(x => x.Food));
    }

    private static void GetFood(List<IBuyer> buyers)
    {
        var namesToBuyFood = string.Empty;
        while ((namesToBuyFood = Console.ReadLine()) != "End")
        {
            if (buyers.Exists(x => x.Name == namesToBuyFood))
            {
                buyers.Find(x => x.Name == namesToBuyFood).BuyFood();
            }

        }
    }

    private static void AddBuyers(int numberOfPeople, List<IBuyer> buyers)
    {
        for (int i = 0; i < numberOfPeople; i++)
        {
            var info = Console.ReadLine().Split();
            switch (info.Length)
            {
                case 3:
                    Rebel currentRebel = new Rebel(info[0], int.Parse(info[1]), info[2]);
                    buyers.Add(currentRebel);
                    break;
                case 4:
                    Citizen curreCitizen = new Citizen(info[0], int.Parse(info[1]), info[2], info[3]);
                    buyers.Add(curreCitizen);
                    break;
            }
        }
    }
}

