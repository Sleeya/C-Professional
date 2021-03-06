﻿namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{
            var performerType = Assembly.GetCallingAssembly().GetTypes()
               .Where(t => typeof(IPerformer).IsAssignableFrom(t))
               .FirstOrDefault();

            var performer = (IPerformer)Activator.CreateInstance(performerType, name, age);

			return performer;
		}
	}
}