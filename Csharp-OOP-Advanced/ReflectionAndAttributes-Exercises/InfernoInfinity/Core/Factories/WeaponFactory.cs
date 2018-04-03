using System;
using System.Linq;
using System.Reflection;
using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Factories
{
    public class WeaponFactory
    {
        public IWeapon CreateWeapon(string rarity, string weaponType, string weaponName)
        {
            Enum.TryParse<WeaponRarity>(rarity, out var resultRarity);
            Assembly assembly = Assembly.GetCallingAssembly();

            Type classType = assembly.GetTypes().FirstOrDefault(x => x.Name == weaponType);

            if (classType == null)
            {
                throw  new ArgumentException("Invalid weapon type!");
            }

            IWeapon weapon = (IWeapon)Activator.CreateInstance(classType, new object[]{resultRarity,weaponName});

            return weapon;
        }
    }
}
