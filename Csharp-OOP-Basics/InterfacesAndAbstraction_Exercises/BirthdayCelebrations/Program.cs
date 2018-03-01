using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<IBirthable> passingObjects = new List<IBirthable>();
        string command = String.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            var input = command.Split();
            string typeOfObject = input[0];
            switch (typeOfObject)
            {
                case "Citizen":
                    Citizen currentCitizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    passingObjects.Add(currentCitizen);
                    break;
                case "Pet":
                    Pet currentPet = new Pet(input[1], input[2]);
                    passingObjects.Add(currentPet);
                    break;
            }
        }

        string birthdaysToPrint = Console.ReadLine();
        foreach (var passingObject in passingObjects.Where(x => x.Birthday.EndsWith(birthdaysToPrint)))
        {
            Console.WriteLine(passingObject.Birthday);
        }

    }
}

