using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        List<Cat> cats = new List<Cat>();
        string[] input = new string[3];
        while ((input=Console.ReadLine().Split())[0]!="End")
        {
            Cat currentCat = new Cat();
            currentCat.Breed = input[0];
            currentCat.Name = input[1];
            switch (input[0])
            {
                case "Siamese":
                    currentCat.EarSize =int.Parse(input[2]);
                    break;
                case "Cymric":
                    currentCat.FurLength = decimal.Parse(input[2]);
                    break;
                case "StreetExtraordinaire":
                    currentCat.DecibelsOfMeows = decimal.Parse(input[2]);
                    break;
             }
            cats.Add(currentCat);
        }


        string name = Console.ReadLine();
        Cat printCat = cats.Find(x => x.Name == name);

        switch (printCat.Breed)
        {
            case "Siamese":
                Console.WriteLine($"{printCat.Breed} {printCat.Name} {printCat.EarSize}");
                break;
            case "Cymric":
                Console.WriteLine($"{printCat.Breed} {printCat.Name} {printCat.FurLength:f2}");
                break;
            case "StreetExtraordinaire":
                Console.WriteLine($"{printCat.Breed} {printCat.Name} {printCat.DecibelsOfMeows}");
                break;
        }
    }
}

