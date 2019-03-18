using System;

namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using Microsoft.Extensions.DependencyInjection;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IServiceProvider provider = ConfigureServices();
            CommandInterpreter interpreter = new CommandInterpreter(provider);
            IRunnable engine = new Engine(interpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IUnitFactory, UnitFactory>();
            services.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider provider = services.BuildServiceProvider();

            return provider;
        }
    }


}
