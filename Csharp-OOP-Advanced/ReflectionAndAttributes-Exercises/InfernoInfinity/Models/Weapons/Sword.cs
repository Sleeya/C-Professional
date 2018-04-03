using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        private const int DEFAULT_MIN_DMG = 4;
        private const int DEFAULT_MAX_DMG = 6;
        private const int DEFAULT_NUMBER_OF_SOCKETS = 3;

        public Sword(WeaponRarity weaponRarity, string name) : base(DEFAULT_MIN_DMG, DEFAULT_MAX_DMG, DEFAULT_NUMBER_OF_SOCKETS, weaponRarity, name)
        {

        }
    }
}
