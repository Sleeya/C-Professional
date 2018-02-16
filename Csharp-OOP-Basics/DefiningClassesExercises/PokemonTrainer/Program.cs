using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        var command = new string[4];
        List<Trainer> trainers = new List<Trainer>();

        while ((command = Console.ReadLine().Split().ToArray())[0] != "Tournament")
        {
            Trainer currentTrainer = new Trainer();
            currentTrainer.Name = command[0];
            currentTrainer.Badges = 0;

            Pokemon currentPokemon = new Pokemon();
            currentPokemon.Name = command[1];
            currentPokemon.Element = command[2];
            currentPokemon.Health = int.Parse(command[3]);


            if (trainers.Any(x => x.Name == currentTrainer.Name))
            {
                trainers.Find(x => x.Name == currentTrainer.Name).AddPokemons(currentPokemon);
            }
            else
            {
                currentTrainer.AddPokemons(currentPokemon);
                trainers.Add(currentTrainer);
            }

        }

        var elements = string.Empty;
        while ((elements = Console.ReadLine()) != "End")
        {
            switch (elements)
            {
                case "Fire":
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Pokemons.Any(x => x.Element == "Fire"))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            foreach (var pokemon in trainer.Pokemons)
                            {
                                pokemon.Health -= 10;
                            }
                            trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                        }
                    }
                    break;
                case "Water":
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Pokemons.Any(x => x.Element == "Water"))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            foreach (var pokemon in trainer.Pokemons)
                            {
                                pokemon.Health -= 10;
                            }
                            trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                        }
                    }
                    break;
                case "Electricity":
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Pokemons.Any(x => x.Element == "Electricity"))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            foreach (var pokemon in trainer.Pokemons)
                            {
                                pokemon.Health -= 10;
                            }
                            trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                        }
                    }
                    break;

            }
        }

        trainers = trainers.OrderByDescending(x => x.Badges).ToList();


        foreach (var trainer in trainers)
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}

