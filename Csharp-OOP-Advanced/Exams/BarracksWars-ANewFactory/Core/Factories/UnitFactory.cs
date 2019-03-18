using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(x => x.Name == unitType);

            if (model == null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }

            IUnit obj = (IUnit)Activator.CreateInstance(model);

            return obj;
        }
    }
}
