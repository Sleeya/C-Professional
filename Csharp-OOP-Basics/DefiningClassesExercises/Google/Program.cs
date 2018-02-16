using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        string[] input = new string[5];
        while ((input = Console.ReadLine().Split().ToArray())[0] != "End")
        {
            string typeOfInput = input[1];
            switch (typeOfInput)
            {
                case "company":
                    if (!people.Any(x => x.Name == input[0]))
                    {
                        Person currentPerson = new Person();
                        currentPerson.Name = input[0];
                        Company currentCompany = new Company();
                        currentCompany.Name = input[2];
                        currentCompany.Department = input[3];
                        currentCompany.Salary = decimal.Parse(input[4]);
                        currentPerson.Company = currentCompany;
                        people.Add(currentPerson);
                    }
                    else
                    {
                        Person currentPerson = people.Find(x => x.Name == input[0]);
                        Company currentCompany = new Company();
                        currentCompany.Name = input[2];
                        currentCompany.Department = input[3];
                        currentCompany.Salary = decimal.Parse(input[4]);
                        currentPerson.Company = currentCompany;
                    }
                    break;
                case "pokemon":
                    if (!people.Any(x => x.Name == input[0]))
                    {
                        Person currentPerson = new Person();
                        currentPerson.Name = input[0];
                        Pokemon currentPokemon = new Pokemon();
                        currentPokemon.Name = input[2];
                        currentPokemon.Type = input[3];
                        currentPerson.AddPokemons(currentPokemon);
                        people.Add(currentPerson);
                    }
                    else
                    {
                        Person currentPerson = people.Find(x => x.Name == input[0]);
                        Pokemon currentPokemon = new Pokemon();
                        currentPokemon.Name = input[2];
                        currentPokemon.Type = input[3];
                        currentPerson.AddPokemons(currentPokemon);
                    }
                    break;
                case "parents":
                    if (!people.Any(x => x.Name == input[0]))
                    {
                        Person currentPerson = new Person();
                        currentPerson.Name = input[0];
                        Parents currentParent = new Parents();
                        currentParent.Name = input[2];
                        currentParent.Birthday = input[3];
                        currentPerson.AddParents(currentParent);
                        people.Add(currentPerson);
                    }
                    else
                    {
                        Person currentPerson = people.Find(x => x.Name == input[0]);
                        Parents currentParent = new Parents();
                        currentParent.Name = input[2];
                        currentParent.Birthday = input[3];
                        currentPerson.AddParents(currentParent);
                    }
                    break;
                case "children":
                    if (!people.Any(x => x.Name == input[0]))
                    {
                        Person currentPerson = new Person();
                        currentPerson.Name = input[0];
                        Children currentChild = new Children();
                        currentChild.Name = input[2];
                        currentChild.Birthday = input[3];
                        currentPerson.AddChildren(currentChild);
                        people.Add(currentPerson);
                    }
                    else
                    {
                        Person currentPerson = people.Find(x => x.Name == input[0]);
                        Children currentChild = new Children();
                        currentChild.Name = input[2];
                        currentChild.Birthday = input[3];
                        currentPerson.AddChildren(currentChild);
                    }
                    break;
                case "car":
                    if (!people.Any(x => x.Name == input[0]))
                    {
                        Person currentPerson = new Person();
                        currentPerson.Name = input[0];
                        Car currentCar = new Car();
                        currentCar.Model = input[2];
                        currentCar.Speed = int.Parse(input[3]);
                        currentPerson.Car = currentCar;
                        people.Add(currentPerson);
                    }
                    else
                    {
                        Person currentPerson = people.Find(x => x.Name == input[0]);
                        Car currentCar = new Car();
                        currentCar.Model = input[2];
                        currentCar.Speed = int.Parse(input[3]);
                        currentPerson.Car = currentCar;
                    }
                    break;

            }
        }

        string nameToPrint = Console.ReadLine();

        PrintPerson(people,nameToPrint);
        

    }

    private static void PrintPerson(List<Person> people, string nameToPrint)
    {
        Person printPerson = people.Find(x => x.Name == nameToPrint);
        Console.WriteLine($"{printPerson.Name}");

        Console.WriteLine("Company:");
        if (printPerson.Company != null)
        {
            Console.WriteLine($"{printPerson.Company.Name} {printPerson.Company.Department} {printPerson.Company.Salary:f2}");
        }

        Console.WriteLine("Car:");
        if (printPerson.Car != null)
        {
            Console.WriteLine($"{printPerson.Car.Model} {printPerson.Car.Speed} ");
        }


        Console.WriteLine("Pokemon:");
        foreach (var pokemon in printPerson.Pokemons)
        {
            Console.WriteLine($"{pokemon.Name} {pokemon.Type}");
        }

        Console.WriteLine("Parents:");
        foreach (var parent in printPerson.Parents)
        {
            Console.WriteLine($"{parent.Name} {parent.Birthday}");
        }

        Console.WriteLine("Children:");
        foreach (var child in printPerson.Children)
        {
            Console.WriteLine($"{child.Name} {child.Birthday}");
        }

    }
}

