
namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            var setType = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => typeof(ISet).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == type);

            var set = (ISet)Activator.CreateInstance(setType,name);

            return set;
		}
	}




}
