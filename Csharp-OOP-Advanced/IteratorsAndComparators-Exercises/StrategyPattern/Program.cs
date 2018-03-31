using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> peopleByName = new SortedSet<Person>(new PersonNameComparator());
        SortedSet<Person> peopleByAge = new SortedSet<Person>(new PersonAgeComparator());

        int numberOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPeople; i++)
        {
            var input = Console.ReadLine().Split();

            peopleByName.Add(new Person(input[0], int.Parse(input[1])));
            peopleByAge.Add(new Person(input[0], int.Parse(input[1])));
        }

        foreach (var person in peopleByName)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }

        foreach (var person in peopleByAge)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}
