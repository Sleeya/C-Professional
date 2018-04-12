using System;
using DependencyInversion.Strategies;

namespace DependencyInversion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var input = command.Split();

                if (input[0] == "mode")
                {
                    var strategyType = input[1];

                    switch (strategyType)
                    {
                        case "+":
                            calculator.ChangeStrategy(new AdditionStrategy());
                            break;
                        case "-":
                            calculator.ChangeStrategy(new SubtractionStrategy());
                            break;
                        case "*":
                            calculator.ChangeStrategy(new MultiplicationStrategy());
                            break;
                        case "/":
                            calculator.ChangeStrategy(new DivisionStrategy());
                            break;
                    }
                }
                else
                {
                    int firstNum = int.Parse(input[0]);
                    int secondNum = int.Parse(input[1]);
                    Console.WriteLine(calculator.PerformCalculation(firstNum, secondNum));
                }
            }
        }
    }
}
