using System;
using System.Collections.Generic;
using System.Text;
using InfernoInfinity.Contracts;
using InfernoInfinity.Enums;

namespace InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        private int strength;
        private int agility;
        private int vitality;

        protected Gem(int strength, int agility, int vitality, GemRarity rarity)
        {
            this.Strength = strength + (int)rarity;
            this.Agility = agility + (int)rarity;
            this.Vitality = vitality + (int)rarity;
        }

        public int Strength
        {
            get => this.strength;
            private set => this.strength = value;
        }

        public int Agility
        {
            get => this.agility;
            private set => this.agility = value;
        }

        public int Vitality
        {
            get => this.vitality;
            private set => this.vitality = value;
        }
    }
}
