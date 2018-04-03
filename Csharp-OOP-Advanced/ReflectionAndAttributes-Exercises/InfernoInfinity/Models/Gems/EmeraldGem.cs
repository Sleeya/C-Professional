using System;
using System.Collections.Generic;
using System.Text;
using InfernoInfinity.Enums;

namespace InfernoInfinity.Models.Gems
{
    public class EmeraldGem : Gem
    {
        private const int DEFAULT_STRENGTH = 1;
        private const int DEFAULT_AGILITY = 4;
        private const int DEFAULT_VITALITY = 9;

        public EmeraldGem(GemRarity rarity) : base(DEFAULT_STRENGTH, DEFAULT_AGILITY, DEFAULT_VITALITY, rarity)
        {
        }
    }
}
