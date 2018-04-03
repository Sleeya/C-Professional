using System;
using System.Collections.Generic;
using System.Text;
using InfernoInfinity.Contracts;
using InfernoInfinity.Models.Gems;
using System.Linq;
using InfernoInfinity.Models.Attributes;

namespace InfernoInfinity.Models
{
    [Inject("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        private int minDmg;
        private int maxDmg;
        private int numberOfSockets;
        private string name;
        private IGem[] gems;

        protected Weapon(int minDmg, int maxDmg, int numberOfSockets, WeaponRarity weaponRarity, string name)
        {
            this.NumberOfSockets = numberOfSockets;
            this.Gems = new Gem[this.NumberOfSockets];
            this.MinDmg = minDmg * (int)weaponRarity;
            this.MaxDmg = maxDmg * (int)weaponRarity;
            this.Name = name;

        }

        public int MinDmg
        {
            get => this.minDmg + (2 * this.Strength) + this.Agility;
            private set => this.minDmg = value;
        }

        public int MaxDmg
        {
            get => this.maxDmg + (3 * this.Strength) + (4 * this.Agility);
            private set => this.maxDmg = value;
        }

        public int NumberOfSockets
        {
            get => this.numberOfSockets;
            private set => this.numberOfSockets = value;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int Strength
        {
            get => this.Gems.Where(x => x != null).Sum(x => x.Strength);
        }

        public int Agility
        {
            get => this.Gems.Where(x => x != null).Sum(x => x.Agility);
        }

        public int Vitality
        {
            get => this.Gems.Where(x => x != null).Sum(x => x.Vitality);
        }

        public IGem[] Gems
        {
            get => this.gems;
            private set => this.gems = value;
        }

        public void AddGem(int index, IGem gem)
        {
            if (index >= 0 && index < this.Gems.Length)
            {
                this.Gems[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < this.Gems.Length)
            {
                this.Gems[index] = null;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDmg}-{this.MaxDmg} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }
    }
}
