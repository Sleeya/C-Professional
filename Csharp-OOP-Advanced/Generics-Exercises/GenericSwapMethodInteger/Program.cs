using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int numerOfInts = int.Parse(Console.ReadLine());
        List<Box<int>> items = new List<Box<int>>();
        for (int i = 0; i < numerOfInts; i++)
        {
            int input = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>(input);
            items.Add(box);
        }

        var swapInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int indexOne = swapInput[0];
        int indexTwo = swapInput[1];

        Swap(items, indexOne, indexTwo);


    }

    public static void Swap<T>(List<T> items, int indexOne, int indexTwo) where T : class
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

