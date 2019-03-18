using System;
using System.Collections.Generic;
using System.Text;
using InfernoInfinity.Enums;

namespace InfernoInfinity.Models.Gems
{
    public class AmethystGem : Gem
    {
        private const int DEFAULT_STRENGTH = 2;
        private const int DEFAULT_AGILITY = 8;
        private const int DEFAULT_VITALITY = 4;

        public AmethystGem(GemRarity rarity) : base(DEFAULT_STRENGTH, DEFAULT_AGILITY, DEFAULT_VITALITY, rarity)
        {
        }
    }
}
