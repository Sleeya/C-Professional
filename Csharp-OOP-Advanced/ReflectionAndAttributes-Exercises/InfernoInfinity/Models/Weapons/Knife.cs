using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int DEFAULT_MIN_DMG = 3;
        private const int DEFAULT_MAX_DMG = 4;
        private const int DEFAULT_NUMBER_OF_SOCKETS = 2;

        public Knife(WeaponRarity weaponRarity, string name) : base(DEFAULT_MIN_DMG, DEFAULT_MAX_DMG, DEFAULT_NUMBER_OF_SOCKETS, weaponRarity, name)
        {

        }
    }
}
