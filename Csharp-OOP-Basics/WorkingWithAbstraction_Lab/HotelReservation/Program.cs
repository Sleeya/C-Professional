using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        PriceCalculator calc = new PriceCalculator(input);

        calc.Calculate();

    }
}

