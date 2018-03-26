using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int numerOfStrings = int.Parse(Console.ReadLine());
        List<Box<double>> items = new List<Box<double>>();
        for (int i = 0; i < numerOfStrings; i++)
        {
            double input = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(input);
            items.Add(box);
        }


        var comparatorValue = double.Parse(Console.ReadLine());

        Console.WriteLine(Box<double>.GetGreaterElementsCount(items, comparatorValue));
    }
}

