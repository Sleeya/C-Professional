
using System;

class Program
{
    static void Main(string[] args)
    {
        string carName = Console.ReadLine();
        ICar car = new Ferrari(carName);
        Console.WriteLine(car);
    }
}

