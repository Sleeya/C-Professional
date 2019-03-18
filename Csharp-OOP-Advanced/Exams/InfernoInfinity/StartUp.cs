using System;
using System.Collections.Generic;
using InfernoInfinity.Contracts;
using InfernoInfinity.Core;
using InfernoInfinity.Factories;
using InfernoInfinity.Models.Factories;

namespace InfernoInfinity
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<IWeapon> weapons = new List<IWeapon>();
            WeaponFactory weaponFactory = new WeaponFactory();
            GemFactory gemFactory = new GemFactory();
            Engine engine = new Engine(weapons,weaponFactory,gemFactory);
            engine.Run();
        }
    }
}
