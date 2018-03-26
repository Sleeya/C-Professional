using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int numerOfStrings = int.Parse(Console.ReadLine());
        List<Box<string>> items = new List<Box<string>>();
        for (int i = 0; i < numerOfStrings; i++)
        {
            string input = Console.ReadLine();

            Box<string> box = new Box<string>(input);
            items.Add(box);
        }


        var comparatorValue = Console.ReadLine();
       
        Console.WriteLine(Box<string>.GetGreaterElementsCount(items,comparatorValue ));
        


    }
}

