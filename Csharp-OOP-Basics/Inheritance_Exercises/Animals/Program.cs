using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        string type = string.Empty;
        while ((type = Console.ReadLine()) != "Beast!")
        {
            try
            {
                string[] animalInfo = Console.ReadLine().Split(" ").ToArray();
                if (animalInfo.Length < 3)
                {
                    throw new ArgumentException("Invalid input!");
                }
                animals.Add(Animal.AssignAnimal(type, animalInfo));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
            animal.ProduceSound();
        }
    }
}

