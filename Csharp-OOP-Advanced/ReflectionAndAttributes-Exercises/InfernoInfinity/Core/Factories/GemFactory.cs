using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using InfernoInfinity.Contracts;
using InfernoInfinity.Enums;

namespace InfernoInfinity.Factories
{
    public class GemFactory
    {
        public IGem CreateGem(string rarity, string gemType)
        {
            Enum.TryParse<GemRarity>(rarity, out var resultRarity);
            Assembly assembely = Assembly.GetCallingAssembly();

            Type model = assembely.GetTypes().FirstOrDefault(x => x.Name == gemType + "Gem");

            if (model == null)
            {
                throw new InvalidOperationException("Invalid gem type!");
            }

            IGem gem = (IGem)Activator.CreateInstance(model, new object[] { resultRarity });

            return gem;
        }
    }
}
