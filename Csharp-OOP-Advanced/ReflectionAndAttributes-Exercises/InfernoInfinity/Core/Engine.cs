using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using InfernoInfinity.Contracts;
using InfernoInfinity.Factories;
using InfernoInfinity.Models;
using InfernoInfinity.Models.Attributes;
using InfernoInfinity.Models.Factories;

namespace InfernoInfinity.Core
{
    public class Engine
    {
        private List<IWeapon> weapons;
        private WeaponFactory weaponFactory;
        private GemFactory gemFactory;
        private bool IsRunning;
        public Engine(List<IWeapon> weapons, WeaponFactory weaponFactory, GemFactory gemFactory)
        {
            this.weapons = weapons;
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
            IsRunning = true;
        }

        public void Run()
        {
            while (this.IsRunning)
            {
                var input = Console.ReadLine().Split(";");
                var command = input[0];

                switch (command)
                {
                    case "Create":
                        string rarity = input[1].Split()[0];
                        string weaponType = input[1].Split()[1];
                        string weaponName = input[2];
                        IWeapon weapon = weaponFactory.CreateWeapon(rarity, weaponType, weaponName);
                        weapons.Add(weapon);
                        break;
                    case "Add":
                        string weaponToSocket = input[1];
                        int socketIndex = int.Parse(input[2]);
                        string gemRarity = input[3].Split()[0];
                        string gemType = input[3].Split()[1];
                        IGem gem = gemFactory.CreateGem(gemRarity, gemType);
                        weapons.Find(x => x.Name == weaponToSocket).AddGem(socketIndex, gem);
                        break;
                    case "Remove":
                        string weaponToRemove = input[1];
                        int socketIndexToRemove = int.Parse(input[2]);
                        weapons.Find(x => x.Name == weaponToRemove).RemoveGem(socketIndexToRemove);
                        break;
                    case "Print":
                        string weaponToPrint = input[1];
                        Console.WriteLine(weapons.Find(x => x.Name == weaponToPrint));
                        break;
                    case "END":
                        IsRunning = false;
                        break;
                    case "Author":
                        Console.WriteLine("Author: " + GetAttribute().Author);
                        break;
                    case "Revision":
                        Console.WriteLine("Revision: " + GetAttribute().Revision);
                        break;
                    case "Description":
                        Console.WriteLine("Class description: " + GetAttribute().Description);
                        break;
                    case "Reviewers":
                        Console.WriteLine("Reviewers: " + string.Join(", ", GetAttribute().Reviewers));
                        break;
                }
            }
        }

        private static InjectAttribute GetAttribute()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type classType = assembly.GetTypes().FirstOrDefault(x => x == typeof(Weapon));
            InjectAttribute attribute =
                (InjectAttribute)classType.GetCustomAttributes().FirstOrDefault(x => x.GetType() == typeof(InjectAttribute));

            return attribute;
        }

    }
}
