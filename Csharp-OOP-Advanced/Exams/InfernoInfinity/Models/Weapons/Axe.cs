using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int DEFAULT_MIN_DMG = 5;
        private const int DEFAULT_MAX_DMG = 10;
        private const int DEFAULT_NUMBER_OF_SOCKETS = 4;

        public Axe(WeaponRarity weaponRarity, string name) : base(DEFAULT_MIN_DMG, DEFAULT_MAX_DMG, DEFAULT_NUMBER_OF_SOCKETS, weaponRarity, name)
        {

        }
    }
}
