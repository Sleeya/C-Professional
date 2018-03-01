using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Citizen> citizens = new List<Citizen>();
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var info = input.Split();
            citizens.Add(new Citizen(info[0], info[1], int.Parse(info[2])));
        }

        foreach (var citizen in citizens)
        {
            (citizen as IPerson).GetName();
            (citizen as IResident).GetName();
        }
    }
}

