using System;

namespace DependencyInversion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator();

            string command;
            while ((command = Console.ReadLine())!="End")
            {
                if (command.StartsWith("mode"))
                {
                    calculator.changeStrategy(command[command.Length - 1]);
                    continue;
                }
                int firstNum = int.Parse(command.Split()[0]);
                int secondNum = int.Parse(command.Split()[1]);

                Console.WriteLine(calculator.performCalculation(firstNum, secondNum));
            }
        }
    }
}
