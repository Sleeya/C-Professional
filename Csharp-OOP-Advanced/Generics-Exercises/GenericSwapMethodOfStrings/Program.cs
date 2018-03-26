using System;
using System.Collections.Generic;
using System.Linq;

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

        var swapInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int indexOne = swapInput[0];
        int indexTwo = swapInput[1];

        Swap(items,indexOne,indexTwo);


    }

    public static void Swap<T>(List<T> items,int indexOne,int indexTwo) where T: class
    {
        var temp = items[indexOne];
        items[indexOne] = items[indexTwo];
        items[indexTwo] = temp;

        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}

