
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;
    using FestivalManager.Core.IO;
    using FestivalManager.Entities.Contracts;

    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalController, ISetController setController)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;

            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }


        public void Run()
        {
            var input = string.Empty;
            while ((input = this.reader.ReadLine()) != "END")
            {
                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
            }

            var reportSummary = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(reportSummary);
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split(" ").ToArray();

            var commandName = tokens.First();
            var commandArgs = tokens.Skip(1).ToArray();

            if (commandName == "LetsRock")
            {
                var setsOutput = this.setCоntroller.PerformSets();
                return setsOutput;
            }

            var festivalcontrolfunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == commandName);

            string result = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { commandArgs });

            return result;
        }
    }
}