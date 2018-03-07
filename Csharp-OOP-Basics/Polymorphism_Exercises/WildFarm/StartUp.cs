
using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        List<Animal> zoo = new List<Animal>();

        PopulateTheZoo(zoo);

        PrintTheZoo(zoo);
    }

    private static void PopulateTheZoo(List<Animal> zoo)
    {
        var command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            var input = command.Split();
            string type = input[0];

            switch (type)
            {
                case "Owl":
                    Animal currentOwl = new Owl(input[1], double.Parse(input[2]), double.Parse(input[3]));
                    currentOwl.SayHungry();
                    FeedAnimal(currentOwl);
                    zoo.Add(currentOwl);
                    break;
                case "Hen":
                    Animal currentHen = new Hen(input[1], double.Parse(input[2]), double.Parse(input[3]));
                    currentHen.SayHungry();
                    FeedAnimal(currentHen);
                    zoo.Add(currentHen);
                    break;
                case "Mouse":
                    Animal currentMouse = new Mouse(input[1], double.Parse(input[2]), input[3]);
                    currentMouse.SayHungry();
                    FeedAnimal(currentMouse);
                    zoo.Add(currentMouse);
                    break;
                case "Dog":
                    Animal currentDog = new Dog(input[1], double.Parse(input[2]), input[3]);
                    currentDog.SayHungry();
                    FeedAnimal(currentDog);
                    zoo.Add(currentDog);
                    break;
                case "Cat":
                    Animal currentCat = new Cat(input[1], double.Parse(input[2]), input[3], input[4]);
                    currentCat.SayHungry();
                    FeedAnimal(currentCat);
                    zoo.Add(currentCat);
                    break;
                case "Tiger":
                    Animal currentTiger = new Tiger(input[1], double.Parse(input[2]), input[3], input[4]);
                    currentTiger.SayHungry();
                    FeedAnimal(currentTiger);
                    zoo.Add(currentTiger);
                    break;
            }

        }
    }

    private static void PrintTheZoo(List<Animal> zoo)
    {
        foreach (var animal in zoo)
        {
            Console.WriteLine(animal);
        }
    }

    public static void FeedAnimal(Animal animal)
    {
        var food = Console.ReadLine().Split();
        var type = food[0];

        switch (type)
        {
            case "Vegetable":
                Food currentVegetable = new Vegetable(int.Parse(food[1]));
                if (CanEat(animal, type))
                {
                    animal.FeedAnimal(currentVegetable.Quantity);
                }
                else
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {type}!");
                }
                break;
            case "Fruit":
                Food currentFruit = new Fruit(int.Parse(food[1]));
                if (CanEat(animal, type))
                {
                    animal.FeedAnimal(currentFruit.Quantity);
                }
                else
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {type}!");
                }
                break;
            case "Meat":
                Food currentMeat = new Meat(int.Parse(food[1]));
                if (CanEat(animal, type))
                {
                    animal.FeedAnimal(currentMeat.Quantity);
                }
                else
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {type}!");
                }
                break;
            case "Seeds":
                Food currentSeeds = new Seeds(int.Parse(food[1]));
                if (CanEat(animal, type))
                {
                    animal.FeedAnimal(currentSeeds.Quantity);
                }
                else
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {type}!");
                }
                break;

        }
    }

    public static bool CanEat(Animal animal, string type)
    {
        switch (animal.GetType().Name)
        {
            case "Hen":
                return true;
            case "Mouse":
                if (type == "Vegetable" || type == "Fruit")
                {
                    return true;
                }

                break;
            case "Cat":
                if (type == "Vegetable" || type == "Meat")
                {
                    return true;
                }

                break;
           default:
                if (type == "Meat")
                {
                    return true;
                }

                break;
        }
        return false;
    }
}

