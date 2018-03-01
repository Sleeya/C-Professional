using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<IIdentifiable> passingObjects = new List<IIdentifiable>();
        string command = String.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            var input = command.Split();
            if (input.Length == 2)
            {
                IIdentifiable robot = new Robot(input[0], input[1]);
                passingObjects.Add(robot);
            }
            else
            {
                IIdentifiable citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                passingObjects.Add(citizen);
            }
        }

        string fakeIdFilter = Console.ReadLine();
        foreach (var passingObject in passingObjects.Where(x=>x.Id.EndsWith(fakeIdFilter)))
        {
            Console.WriteLine(passingObject.Id);
        }
    }
}
