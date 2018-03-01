
using System;

class Program
{
    static void Main(string[] args)
    {
        string[] callNumbers = Console.ReadLine().Split();
        string[] websites = Console.ReadLine().Split();

        Smartphone phone = new Smartphone(callNumbers,websites);

        phone.Call();
        phone.Browse();


    }
}

