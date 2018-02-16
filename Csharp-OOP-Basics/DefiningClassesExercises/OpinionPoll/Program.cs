using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
       List<Person> people = new List<Person>();

        int numberOfPeople = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfPeople; i++)
        {
            var input = Console.ReadLine().Split();

            Person currentPerson = new Person();

            currentPerson.Name = input[0];
            currentPerson.Age = int.Parse(input[1]);
            people.Add(currentPerson);
        }

        foreach (var person in people.Where(x=>x.Age>30).OrderBy(x=>x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
        
    }
}
