using System;
using System.Collections.Generic;
using Logger.Models.Contracts;
using Logger.Models.Factories;

namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ILogger logger = InitializeLogger();
            ErrorFactory factory = new ErrorFactory();
            Engine engine = new Engine(logger,factory);
            engine.Run();
        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int numberOfAppenders = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfAppenders; i++)
            {
                var args = Console.ReadLine().Split();

                string appenderType = args[0];
                string layoutType = args[1];
                string errorLevel = "INFO";
                if (args.Length == 3)
                {
                    errorLevel = args[2];
                }

                IAppender appender = appenderFactory.GenerateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            ILogger logger = new Models.Loggers.Logger(appenders);

            return logger;
        }
    }
}

