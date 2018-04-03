using System;
using System.Collections.Generic;
using System.Text;
using InfernoInfinity.Enums;

namespace InfernoInfinity.Models.Gems
{
    public class RubyGem:Gem
    {
        private const int DEFAULT_STRENGTH = 7;
        private const int DEFAULT_AGILITY = 2;
        private const int DEFAULT_VITALITY = 5;

        public RubyGem(GemRarity rarity) : base(DEFAULT_STRENGTH, DEFAULT_AGILITY, DEFAULT_VITALITY, rarity)
        {
        }
    }
}
