using System;
using System.Collections.Generic;

public class Box<T> 
{
    private T value;

    public Box(T value) 
    {
        this.value = value;
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

    

    public static int GetGreaterElementsCount<T>(List<Box<T>> items, T element) where T : IComparable<T>
    {
        int count = 0;

        foreach (var item in items)
        {
            if (item.value.CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }



    public override string ToString()
    {
        return $"{this.value.GetType().FullName}: {this.value}";
    }
}
